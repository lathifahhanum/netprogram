(function Login() {
    'use strict'

    var forms = document.querySelectorAll('.needs-validation')
    Array.prototype.slice.call(forms).forEach(function (form) {
        form.addEventListener('submit', function (event) {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }

            form.classList.add('was-validated')

            if (form.checkValidity() === true) {
                event.preventDefault();
                form.classList.remove('was-validated')

                var obj = new Object();
                obj.email = $('#loginEmail').val();
                obj.password = $('#loginPass').val();

                $.ajax({
                    url: "https://localhost:44302/api/Account/Auth/",
                    type: "POST",
                    contentType: "application/json",
                    dataType: "JSON",
                    data: JSON.stringify(obj),
                }).done((result) => {
                    //console.log(result.token);
                    alert("Login berhasil.");
                    sessionStorage.setItem("JWToken", result.token);
                    window.location.href = "/Home";
                }).fail((error) => {
                    console.log(JSON.stringify(error));
                    alert("Login gagal.")
                })
            }
        }, false)
    })
})()

//function Login() {
////$('#btnLogin').click(function (e) {
//    //    e.preventDefault();
//    var obj = new Object();
//    obj.email = $('#loginEmail').val();
//    obj.password = $('loginPass').val();

//    $.ajax({
//        url: "https://localhost:44302/api/Account/Auth/",
//        type: "POST",
//        contentType: "application/json",
//        dataType: "JSON",
//        data: JSON.stringify(obj),
//    }).done((result) => {
//        console.log(token);
//        alert(result.token);
//        //localStorage.setItem('JWToken', data.token);
//    }).fail((error) => {
//        console.log(error);
//        //alert(JSON.stringify(error));

//    })
////})

//}
