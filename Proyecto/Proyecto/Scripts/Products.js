function OpenDialog() {
    var Id = $("#Id").val();
    if (Id == 0) {
        var Name = $("#Name").val();
        var CategoryId = $("#CategoryId").val();
        $.ajax({
            type: 'post',
            url: '/Products/AddProductAsync',
            data: {
                'Name': Name,
                'CategoryId': CategoryId
            },
            success: function (response) {
                $("#Id").val(response.Id);
            }
        });
    }
    $('#modal1').modal('open');
}
function AddVarriant() {
    var Id = $("#VariantId").val();
    var Price = $("#Price").val();
    var ProductId = $("#Id").val();
    $.ajax({
        type: 'post',
        url: '/Products/AddVariant',
        data: {
            'Id': Id,
            'ProductId': ProductId,
            'Price': Price

        },
        success: function (response) {

            $("#VariantId").val(response.Id);
            VerfProductAttribute();
        },
        error: function (response) {
            console.log("Error Creando Vairante")
        }
    });

}
function VerfProductAttribute() {

    var AttributeName = $("#AttributeName").val();
    var AttributeValue = $("#AttributeValue").val();
    if (AttributeName != '' && AttributeValue != '') {
        $.ajax({
            type: 'post',
            url: '/Products/FindAttribute',
            data: {
                'AttributeName': AttributeName
            },
            success: function (response) {
                $("#AttributeId").val(response.Id);
                FindValueAttribute();
            },
            error: function (response) {
                AddAttribute();
            }
        });
    }

}
function FindValueAttribute() {
    var AttributeId = $("#AttributeId").val();
    var AttributeValue = $("#AttributeValue").val();
    console.log(AttributeValue);
    console.log(AttributeId);
    $.ajax({
        type: 'post',
        url: '/Products/FindValueAttribute',
        data: {
            'AttributeId': AttributeId,
            'AttributeValue': AttributeValue
        },
        success: function (response) {
            console.log(response.Id);
            $("#AttributeValueId").val(response);
            AddVarriantAtribute();
        },
        error: function (response) {
            console.log("Me cago");
            AddValueAttribute();
        }
    });
}
function AddAttribute() {
    var AttributeName = $("#AttributeName").val();
    var AttributeId = $("#AttributeId").val();
    $.ajax({
        type: 'post',
        url: '/Products/AddAttribute',
        data: {
            'AttributeName': AttributeName
        },
        success: function (response) {
            $("#AttributeId").val(response.Id);
            AddValueAttribute();

        },
        error: function (response) {

        }
    });
}
function AddValueAttribute() {
    var AttributeId = $("#AttributeId").val();
    var AttributeValue = $("#AttributeValue").val();
    console.log(AttributeId);
    console.log(AttributeValue);
    $.ajax({
        type: 'post',
        url: '/Products/AddValueAttribute',
        data: {
            'AttributeId': AttributeId,
            'AttributeValue': AttributeValue
        },
        success: function (response) {
            $("#AttributeValueId").val(response.Id);
            AddVarriantAtribute();
        },
        error: function (response) {

        }
    });
}
function AddVarriantAtribute() {
    console.log("LLegamos");
    console.log(VariantId.defaultValue);
    AttributeValueId = $("#AttributeValueId").val();
    console.log(AttributeValueId);
    $.ajax({
        type: 'post',
        url: '/Products/AddVarriantAtribute',
        data: {
            'VariantId': VariantId.defaultValue,
            'AttributeValueId': AttributeValueId
        },
        success: function (response) {


            var Attri = "<div class='col s5'>" + $("#AttributeName").val() + "</div>";
            var Valor = "<div class='col s3'>" + $("#AttributeValue").val() + "</div>";
            var boton = "<div class='col s2'><a class='waves-effect waves-light btn red' onclick='DeleteAttribute(" + response.Id + ")'><i class='material-icons'>delete</i></a></div>";
            var item = "<li class='collection-item' id='" + response.Id + "'><div class='row'>" + Attri + Valor + boton + "</div></li>";

            $('#Atributos').append(item);

        },
        error: function (response) {

        }
    });
}
function DeleteVariant(obj) {
    $.ajax({
        type: 'post',
        url: '/Products/DeleteVariant',
        data: {
            'ProductVariantId': obj
        },
        success: function (response) {
            $(('#Variantes #').concat(response.Id)).remove();
        },
        error: function (response) {

        }
    });
    console.log(obj);
}
function DeleteAttribute(obj) {
    $.ajax({
        type: 'post',
        url: '/Products/DeleteAttribute',
        data: {
            'VarriantAtributeId': obj
        },
        success: function (response) {
            $(('#Atributos #').concat(response.Id)).remove();
        },
        error: function (response) {

        }
    });
    console.log(obj);
}
$(document).ready(function () {
    $(function () {
        var id = $("#Id").val();
        $.ajax({
            type: 'post',
            url: '/Categories/BuscarCategorias',
            data: ('Id=').concat(id),
            success: function (response) {
                var CatArray = response;
                var dataCat = {};
                for (var i = 0; i < CatArray.length; i++) {
                    //console.log(countryArray[i].name);
                    dataCat[CatArray[i].Name] = {
                        id: CatArray[i].Id
                    }; //countryArray[i].flag or null
                }
                $('#CategoryName').autocomplete({
                    data: dataCat,
                    limit: 5, // The max amount of results that can be shown at once. Default: Infinity.
                    onAutocomplete: function (data) {
                        // Callback function when value is autcompleted.

                        $("#CategoryId").val(dataCat[data].id);
                    },
                    minLength: 1, // The minimum length of the input for the autocomplete to start. Default: 1.
                });
            }
        });

    });
});