// Отримати посилання на випадаючий список
var accountSelectEdit = document.getElementById("accountSelectEdit");
var accountSelectHist = document.getElementById("accountSelectHistory");

// Отримати посилання на контейнер форми редагування
var editFormContainer = document.getElementById("EditForm");
var checkOrderFormContainer = document.getElementById("HystoryTable");

// Перевірити URL поточної сторінки
if (window.location.pathname === "/ClientOperation/EditClientInf") {
    // Додати обробник події для події вибору
    accountSelectEdit.addEventListener("change", function () {
        var selectedAccountId = accountSelectEdit.value; // Отримати вибране значення

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
}
else if (window.location.pathname === "/ClientOperation/CheckClientOrderHistory") {
    // Додати обробник події для події вибору
    accountSelectHist.addEventListener("change", function () {
        var selectedAccountId = accountSelectHist.value; // Отримати вибране значення

        // Відправити значення на сервер за допомогою AJAX-запиту
        $.ajax({
            url: "/ClientOperation/CheckClientOrderHistory",
            method: "GET",
            data: { id: selectedAccountId },
            success: function (data) {
                // Оновити тільки внутрішність контейнера форми редагування
                $(checkOrderFormContainer).html(data);
            },
            error: function (error) {
                // Обробити помилку, якщо її виникає
                console.log(error);
            }
        });
    });
}
