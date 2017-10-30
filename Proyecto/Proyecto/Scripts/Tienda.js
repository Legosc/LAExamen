$(document).ready(function () {
	$(function () {
        var id = $("#Id").val();
        $.ajax({
            type: 'post',
            url: '/Home/ListCategories',
            
            success: function (response) {
                
                console.log(response);
                
            }
        });
    });

    
});