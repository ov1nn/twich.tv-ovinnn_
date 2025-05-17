document.addEventListener('DOMContentLoaded', function () {
    var form = document.querySelector('form');
    if (!form) return;

    form.addEventListener('submit', function (event) {
        var username = document.querySelector('input[name="Username"]').value.trim();
        var password = document.querySelector('input[name="Password"]').value;
        var confirmPassword = document.querySelector('input[name="ConfirmPassword"]').value;

        var errors = document.querySelectorAll('span[data-valmsg-for]');
        for (var i = 0; i < errors.length; i++) {
            errors[i].textContent = '';
        }

        var hasError = false;

        if (username === '') {
            var errorUsername = document.querySelector('span[data-valmsg-for="Username"]');
            if (errorUsername) {
                errorUsername.textContent = 'Введите имя пользователя';
            }
            hasError = true;
        }

        if (password.length < 1) {
            var errorPassword = document.querySelector('span[data-valmsg-for="Password"]');
            if (errorPassword) {
                errorPassword.textContent = 'Пароль должен быть больше, чем один символ';
            }
            hasError = true;
        }

        if (password !== confirmPassword) {
            var errorConfirm = document.querySelector('span[data-valmsg-for="ConfirmPassword"]');
            if (errorConfirm) {
                errorConfirm.textContent = 'Пароли не совпадают';
            }
            hasError = true;
        }

        if (hasError) {
            event.preventDefault();
        }
    });
});
