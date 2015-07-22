$(function () {
    $('#dialog').dialog({
        buttons: [
            {
                text: "OK",
                click: function () {
                    var formData = new FormData();
                    var data = [document.getElementById("username").value, document.getElementById("email").value, document.getElementById("password").value];
                    var xhr = new window.XMLHttpRequest();
                    xhr.open("post", "http://localhost:13905/Account/JsRegister", true);
                    formData.append("data", data);
                    xhr.send(formData);
                    xhr.onreadystatechange = function () {
                        if (xhr.readyState == 4) {
                            $('#dialog').dialog("close");
                            alert("Registration complete.");
                        }
                    }
                }
            }
        ],
        modal: true,
        autoOpen: false,
        draggable: false,
        width: 340
    });

    $('#shows').click(function () {
        $('#dialog').dialog("open");
    });

});

function success(data) {
    var rezult = "";
    $.each(data, function (index, elem) {
        rezult += "<li>" + elem.Text + "</li>";
    });
    $('#comments').append(rezult);
}

function answer(data) {
    var rezult = "";
    $.each(data, function (index, elem) {
        rezult += "<li class=\"block\"><h4>" + elem.Surname + " " + elem.Name + "</h4><h5>Age: " + elem.Age + "</h5><h5>Number: " + elem.Number + "</h5></li>";
    });
    $('#targetList').append(rezult);
}