$(function () {
    $(".delete").click(function () {
        let id = $(this).attr("id");
        Swal.fire({
            title: "Are You Sure?",
            showCancelButton: true,
            confirmButtonText: "Delete",
            cancelButtonText: "Cancel"
        }).then(function (result) {
            if (result.isConfirmed) {
                $.ajax({
                    type: "Post",
                    dataType: "Json",
                    url: "/Exam/Delete",
                    data: { id: id },
                    success: function (response) {
                        Swal.fire({
                            title: "Completed!",
                            confirmButtonText: "Ok"
                        }).then(function (result) {
                            if (result.isConfirmed)
                                location.reload();
                        });
                    }
                });
            }

        });
    });
});


