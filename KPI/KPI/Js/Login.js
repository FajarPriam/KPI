$(document).ready(function () {
    getRole();
})

function getRole() {
    $.ajax({
        type: "GET",
        dataType: "json",
        contentType: "application/json",
        url: $("#hd_path").val() + "getRole",
        success: function (result) {
            if (result.Status) {
                console.log(result.Data)
                var l = result.Data;
                $("#role").append(new Option('Role', 0));
                $.each(l, function (key, item) {
                    //console.log(keydsa);
                    //console.log(item);
                    $("#role").append(new Option(item.ROLE, item.ID));
                })
            }
            else {
                alert(result.Error);
            }
        }
    })
}

function login() {
    console.log('masuk login');
    var obj = {
        user: $("#user").val()
        , role: $("#role").val()
        , pass: $("#pass").val()
    }

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: $("#hd_path").val() + "login",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Status == true) {
                console.log(result.StatusLogin);
                if (result.StatusLogin == 1) {
                    getSession();
                } else if (result.StatusLogin == 2) {
                    alert("user tidak terdaftar dengan role tersebut!!");
                } else {
                    alert("username/password salah!!");
                }
            } else {
                alert(result.Error);
            }
        }
    })
}

function getSession() {
    console.log('masuk get sesion');
    var obj = {
        user: $("#user").val()
        , role: $("#role").val()
        , pass: $("#pass").val()
    }

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: $("#hd_path").val() + "getSession",
        data: JSON.stringify(obj),
        success: function (result) {
            if (result.Status == true) {
                setSession(result.Data);
            } else {
                alert(result.Error);
            }
        }
    })
}

function setSession(data) {
    console.log('masuk set sesion');
    var obj = {
        NRP: data.USER
        , NAME: data.NAME
        , ID_ROLE: data.ID_ROLE
        , ROLE: data.ROLE
        , DISTRICT: data.DSTRCT_CODE
        , POSITION_ID: data.POSITION_ID
        , POS_TITLE: data.POS_TITLE
    };
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: "Login/setSession",
        data: JSON.stringify(obj),
        success: function (result) {
            window.location.href = "/Home/Index";
        }
    })
}

