// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function loadProjects() {

    $.ajax({
        url: `/api/Customers1/optionCustomer`,
        method: 'GET',
        contentType: 'application/json'
    }).done(response => {

        let divText = "<ul>"
        response.forEach(function (item) {
            divText = divText + "<li>" + item.Title + "</li>"
        })
        divText = divText + "</ul>"

        $('#CustomersContent').html(divText)
    }).fail(failure => {

        $('#CustomersContent').html('Error in the communication')
    }).always(response => {
        console.log(response);
    });
}