const exceptionHandler = {
    handleView: function (data) {
        if (data) {
            alert(data.message);
        }
    },

    handleResponse: function (data) {
        alert(data.message);
    }
};