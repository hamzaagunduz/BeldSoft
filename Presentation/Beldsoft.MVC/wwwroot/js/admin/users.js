// Pagination
var pageSize = parseInt($('#pageSizeSelect').val());

function loadUsers(pageNumber = 1) {
    $.ajax({
        url: '/admin/users/GetPagedUsers',
        type: 'GET',
        data: { pageNumber: pageNumber, pageSize: pageSize },
        beforeSend: function () {
            showSpinner();
        },
        success: function (html) {
            $('#usersTableBody').html(html);
        },
        error: function () {
            alert("Kullanıcılar yüklenirken bir hata oluştu.");
        },
        complete: function () {
            hideSpinner();
        }
    });
}

$(document).ready(function () {
    loadUsers(1);

    $('#pageSizeSelect').change(function () {
        pageSize = parseInt($(this).val());
        loadUsers(1);
    });

    $(document).on('click', '.datatable-pagination-list-item-link', function (e) {
        e.preventDefault();
        var page = $(this).data('page');
        if (page) loadUsers(page);
    });

    // Kullanıcı ekleme
    $('#addUserBtn').click(function () {
        var form = $('#addUserForm')[0];
        if (!form.checkValidity()) {
            form.reportValidity();
            return;
        }
        var formData = new FormData(form);
        $.ajax({
            url: '/admin/users/AddUser',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (res) {
                alert("Kullanıcı eklendi!");
                $('#addUser').modal('hide');
                loadUsers(1);
                $('#addUserForm')[0].reset();
            },
            error: function (xhr) {
                let errors = xhr.responseJSON;
                alert("Hata: " + (errors ? JSON.stringify(errors) : "Bilinmeyen hata"));
            }
        });
    });

    // Kullanıcı silme
    $(document).on('click', '.delete-user-btn', function (e) {
        e.preventDefault();
        var userId = $(this).data('userid');
        if (!confirm("Bu kullanıcıyı silmek istediğinize emin misiniz?")) return;

        $.ajax({
            url: '/admin/users/DeleteUser',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ UserId: userId }),
            success: function () {
                alert("Kullanıcı silindi!");
                loadUsers(1);
            },
            error: function (xhr) {
                let errors = xhr.responseJSON;
                alert("Hata: " + (errors ? JSON.stringify(errors) : "Bilinmeyen hata"));
            }
        });
    });

    // Kullanıcı güncelleme
    $(document).on('click', '.edit-user-btn', function (e) {
        e.preventDefault();
        $('#updateUserId').val($(this).data('userid'));
        $('#updateName').val($(this).data('name'));
        $('#updateSurname').val($(this).data('surname'));
        $('#updatePhone').val($(this).data('phone'));
        $('#updateEmail').val($(this).data('email'));
        $('#updateRole').val($(this).data('role'));
        $('#updateUser').modal('show');
    });

    $('#updateUserBtn').click(function () {
        var form = $('#updateUserForm')[0];
        if (!form.checkValidity()) {
            form.reportValidity();
            return;
        }
        var formData = new FormData(form);
        $.ajax({
            url: '/admin/users/UpdateUser',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function () {
                alert("Kullanıcı güncellendi!");
                $('#updateUser').modal('hide');
                loadUsers(1);
            },
            error: function (xhr) {
                let errors = xhr.responseJSON;
                alert("Hata: " + (errors ? JSON.stringify(errors) : "Bilinmeyen hata"));
            }
        });
    });
});
