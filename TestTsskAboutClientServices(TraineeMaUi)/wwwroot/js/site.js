// Отримати посилання на випадаючий список
var accountSelect = document.getElementById("accountSelect");

// Отримати посилання на контейнер форми редагування
var editFormContainer = document.getElementById("EditForm");

// Додати обробник події для події вибору
accountSelect.addEventListener("change", function () {
    var selectedAccountId = accountSelect.value; // Отримати вибране значення

    // Відправити значення на сервер за допомогою AJAX-запиту
    $.ajax({
        url: "/ClientOperation/EditClientInf",
        method: "GET",
        data: { id: selectedAccountId },
        success: function (data) {
            // Оновити тільки внутрішність контейнера форми редагування
            $(editFormContainer).html(data);
        },
        error: function (error) {
            // Обробити помилку, якщо її виникає
            console.log(error);
        }
    });
});



