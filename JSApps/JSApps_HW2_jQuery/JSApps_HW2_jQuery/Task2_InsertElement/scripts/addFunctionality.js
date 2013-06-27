$('button').on('click', function () {
    var container = $('.container');
    var item = $(this).attr('id');
    var toAdd = $('<div></div>');
    toAdd.addClass('child');
    
    if (item === "before") {
        toAdd.addClass('before-child');
        container.prepend(toAdd);
    } else {
        toAdd.addClass('after-child');
        container.append(toAdd);
    }
})