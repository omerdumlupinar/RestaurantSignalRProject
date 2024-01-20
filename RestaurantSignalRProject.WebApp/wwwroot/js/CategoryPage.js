/// <reference path="../../wwwroot/ready-dashboard/assets/js/core/jquery.3.2.1.min.js" />
$(document).ready(function () {
    CategoryPage.Init();
});

var CategoryPage = {
    Init: function () {
        this.Event(); 7
        this.PrepareHtml();
    },
    Event: function () {
        var _this = this;
        $("body")
            .on("click", "#btn-Save", function () {
                _this.Add();
            })
            .on("click", "#btn-Delete", function () {
                var id = $(this).data("id");
                _this.Delete(id);
            })

    },
    Add: function () {

        var createCategoryDtos = {
            CategoryName: $("#CategoryName").val(),
            Status: true
        };

        $.ajax({
            type: "POST",
            url: "/Category/Add/",
            data: JSON.stringify(createCategoryDtos),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response) {
                    Swal.fire({
                        position: "top-end",
                        icon: "success",
                        title: "Yeni kategori Kayıdı Başarılı.",
                        showConfirmButton: false,
                        timer: 1500,
                        customClass: {
                            popup: 'small-swal',
                        },
                        didClose: () => {
                            window.location.reload();
                        }
                    });

                }
                else {
                    Swal.fire({
                        position: "top-end",
                        icon: "error",
                        title: "Kayıt Sırasında Hata ile Karşılaşıldı. Lütfen Tekrar Deneyiniz",
                        showConfirmButton: false,
                        timer: 1500,
                        customClass: {
                            popup: 'small-swal',
                        },
                        didClose: () => {
                            window.location.reload();
                        }
                    });
                }

            },
            error: function (error) {
                console.error("Hata oluştu:", error);
            }
        });
    },

    Delete: function (id) {
        $.ajax({
            type: "POST",
            url: "/Category/Delete/",
            data: JSON.stringify(id),
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response) {
                    Swal.fire({
                        position: "top-end",
                        icon: "success",
                        title: "Kategori Silme İşlemi Başarılı.",
                        showConfirmButton: false,
                        timer: 1500,
                        customClass: {
                            popup: 'small-swal',
                        }
                    }).then((result) => {
                        window.location.reload();
                    });
                }
                else {
                    Swal.fire({
                        position: "top-end",
                        icon: "error",
                        title: "Silme Sırasında Hata ile Karşılaşıldı. Lütfen Tekrar Deneyiniz",
                        showConfirmButton: false,
                        timer: 1500,
                        customClass: {
                            popup: 'small-swal',
                        }
                    }).then((result) => {
                        window.location.reload();
                    });
                }
            },
            error: function (error) {
                console.error("Hata oluştu:", error);

                // Hata durumunda da Sweet Alert kullanabilirsiniz
                Swal.fire({
                    position: "top-end",
                    icon: "error",
                    title: "Bir Hata Oluştu. Lütfen Daha Sonra Tekrar Deneyiniz",
                    showConfirmButton: false,
                    timer: 1500,
                    customClass: {
                        popup: 'small-swal',
                    }
                });
            }
        });
    },



    GetList: function () {
        var tableItems = ``;
        $.ajax({
            type: "Get",
            url: "/Category/GetList/",
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (reponsData) {
                for (var i in reponsData) {
                    let data = reponsData[i];
                    tableItems += `<tr>
                                     <td>${data.id}</td>
                                     <td>${data.categoryName}</td>
                                     <td>${data.status == true?"Aktiv":"Pasif"}</td>
                                     <td> <a href="#" id="btn-Delete" class="btn btn-outline-danger" onclick="CategoryPage.Delete(${data.id})">Sil</a> </td>
                                     <td> <a href="#" id="btn-Update" class="btn btn-outline-success" onclick="CategoryPage.Update(${data.id})">Güncelle</a></td>
                                  </tr>`;
                }
            },
            error: function (error) { }
        })

        return tableItems;
    },





    PrepareHtml: function () {
        let content = ``,
            tableBody = this.GetList();

        content += `
        <h4 class="page-title">Kategori İşlemleri</h4>
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header row col-md-12">
                        <div class="card-title col-md-10">Kategori Listesi</div>
                        <div class="col-md-2 text-end">
                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                                <i class="fa-solid fa-plus"></i>
                                Yeni Kategori Ekle
                            </button>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="card-sub">
                            Kategori ile ilgili işlemleri aşağıda gerçekleştirebilirsini ;)
                        </div>
                        <table class="table mt-3">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Adı</th>
                                    <th scope="col">Durum</th>
                                    <th scope="col">Sil</th>
                                    <th scope="col">Güncelle</th>
                                </tr>
                            </thead>
                            <tbody>
                                ${tableBody}
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>`;

        $(".table-content").html(content);

    },







}
