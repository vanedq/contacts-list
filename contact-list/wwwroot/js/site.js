$(document).ready(function () {
    $('#contacts-table').DataTable({
        dom:
            '<"second text-center"f>rt<"text-center mt-2"p><"text-end mt-2 mb-4"l>',
        "ordering": false,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "No contacts added.",
            "sInfoEmpty": "Nothing to show in this page.",
            "sInfoFiltered": "(filtered from _MAX_ total contacts)",
            "sLengthMenu": "<span class='me-2'>Contacts per page:</span> _MENU_",
            "sSearch": "<span class='me-2'>Search:</span>",
        }
    });
});

$('.btn-outline-success').click(function () {
    $('.alert-success').hide('hide');
});

$('.btn-outline-danger').click(function () {
    $('.alert-danger').hide('hide');
});         