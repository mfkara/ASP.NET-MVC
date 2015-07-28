function ucusAra() {
    var gidis = $('#Gidis').val();
    //var donus = $('#Donus').val();
    var kalkis = $('#Kalkis').jqxDropDownList('getSelectedItem').value;
    var varis = $('#Varis').jqxDropDownList('getSelectedItem').value;
    var t = new Date();
    t.format("dd-");
    var gecerliGun = t.getDate();
    var gecerliAy = t.getMonth() + 1;
    var gecerliYil = t.getFullYear();
    
    gidis = gecerliAy + "/" + gecerliGun + "/" + gecerliYil;
    var postData = {
        kalkis: kalkis,
        varis: varis,
        tarih: gidis

    };
   
    




    $.ajax({
        type: "POST",
        url: "ucusAra",
        data: JSON.stringify(postData),
            //"{gidis:'" + gidis +
        //    "',donus:'" + donus +
        //    "',kalkis:'" + kalkis +
        //    "',varis:'" + varis +
        //     "'}",
        contentType: "application/json; charset=utf-8",
        datatype: "jsondata",
        async: "true",
        success: function (response) {
            $(".errMsg ul").remove();

            //var myObject = eval('(' + response.d + ')');

                bindData();
                $('#ugrid').jqxGrid('updatebounddata');
                $(".errMsg").append("<ul><li>Data bound successfully</li></ul>");
                
            
            //else {
            //    $(".errMsg").append("<ul><li>Opppps something went wrong.</li></ul>");
            //}
            //$("#popupWindowTitle").jqxWindow('hide');
            $(".errMsg").show("slow");
        },
        error: function (response) {
            alert(response.status + ' ' + response.statusText);
        }
    });



}