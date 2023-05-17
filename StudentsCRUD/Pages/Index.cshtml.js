$(function () {

    // DELETING ITEMS /////////////////////////////////////////
    $('#StudentList').on('click', 'li i', function () {
        var $li = $(this).parent();
        var id = $li.attr('data-id');

        todoApp.services.todo.delete(id).then(function () {
            $li.remove();
            abp.notify.info('Deleted the Student.');
        });
    });

    // CREATING NEW ITEMS /////////////////////////////////////
    $('#NewItemForm').submit(function (e) {
        e.preventDefault();

        var todoText = $('#NewItemText').val();
        todoApp.services.todo.create(todoText).then(function (result) {
            $('<li data-id="' + result.id + '">')
                .html('<i class="fa fa-trash-o"></i> ' + result.text)
                .appendTo($('#StudentList'));
            $('#NewItemText').val('');
        });
    });
});

