
document.addEventListener('keydown', function (event) {
    var escapeEvent = event.which == 27,
      enterEvent = event.which == 13,
      target = event.target,
      input = target.nodeName == 'DIV',
      data = {};

    if (input) {

        if (escapeEvent) {
            // restore state
            document.execCommand('undo');
            target.blur();

        } else if (enterEvent) {
            // save
            data.value = $(target).html();
            data.name = target.getAttribute('data-type');
            data.id = target.getAttribute('data-id');

            // we could send an ajax request to update the field

            $.ajax({
                url: window.location.toString(),
                data: data,
                type: 'post'
            });

            log(JSON.stringify(data));

            target.blur();
            event.preventDefault();
        }
    }
}, true);

    function log(s) {
        document.getElementById('debug').innerHTML = 'value changed to: ' + s;
    }