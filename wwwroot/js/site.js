//Eventos de reistro
$('.alert').hide();
$(document).on('submit', '#Registrar', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Registrar button[type=submit]').prop('disabled', true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
            $('.alert').show();
            $('.alert').text('Usuario registrado con éxito');
        },
        error: function (xhr, status) {
            $('.alert').show();
            $('.alert').text('Oh no! Se presentó un problema' + xhr.responseJSON.Message);
        },
        complete: function () {
            $('#Registrar button[type=submit]').prop('disabled', false);
        }
    })
});
//Eventos de incio de sesion
$(document).on('submit', '#Login', function (e) {
    e.preventDefault();
    $.ajax({
        beforeSend: function () {
            $('#Login button[type=submit]').prop('disabled', true);
        },
        type: this.method,
        url: this.action,
        data: $(this).serialize(),
        success: function (data) {
        },
        error: function (xhr, status) {
            $('.alert').show();
            $('.alert').text('Oh no! Se presentó un problema' + xhr.responseJSON.Message);
        },
        complete: function () {
            $('#Login button[type=submit]').prop('disabled', false);
        }
    });
});