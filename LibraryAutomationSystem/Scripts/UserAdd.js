
$(document).ready(function () {
    $("#Name").attr("autocomplete", "off");
    $("#Surname").attr("autocomplete", "off");
    $("#Username").attr("autocomplete", "off");
    $("#Password").attr("autocomplete", "off");
    $("#Mail").attr("autocomplete", "off");

})
$("#btn").on('click', function () {
    $("#Name").val()
    (
    $.trim($("#Name").val())
    )
    $("#Surname").val()
    (
    $.trim($("#Surname").val())
    )
    $("#UserName").val()
    (
     $.trim($("#UserName").val())
    )
    $("#Password").val()
    (
      $.trim($("#Password").val())
    )
    $("#Mail").val()
    (
    $.trim($("#Mail").val())
    )
});


