$(document).ready(function () {
	$(function () {
        var id = $("#Id").val();
        $.ajax({
            type: 'post',
            url: '/Home/ListCategories',
            
            success: function (response) {
                
                
                var obj = jQuery.parseJSON(response);
				console.log(obj);


				$.each(attri, function (key, data) {
        		var tr = "<li> class='collection-item' id='"+ data.Id+"'</li>";
        		var Attri = "<div class='col s5'>" + data.Description + "</div>";
	            var Valor = "<div class='col s3'>" + data.Value + "</div>";
	            var boton = "<div class='col s2'><a class='waves-effect waves-light btn red' onclick='DeleteAttribute(" + data.Id + ")'><i class='material-icons'>delete</i></a></div>";
	            var item = "<li class='collection-item' id='" + data.Id + "'><div class='row'>" + Attri + Valor + boton + "</div></li>";
	            $('#Atributos').append(item);
			})







            }
        });
    });

    
});