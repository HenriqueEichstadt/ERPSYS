
function successNotify(message) {
    $.notify({
        message: message
    }, {
        type: 'success'
    });
}

function errorNotify(message) {
    $.notify({
        message: message
    }, {
        type: 'danger'
    });
}

function warningNotify(message) {
    $.notify({
        message: message
    }, {
        type: 'warning'
    });
}
