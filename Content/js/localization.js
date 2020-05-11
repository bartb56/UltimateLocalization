var _localiztion = {

    getValueByName: function (resourceName) {
        var getUrl = window.location;
        var baseUrl = getUrl.protocol + "//" + getUrl.host + "/"

        var result;
        $.ajax({
            url: baseUrl + "Localization/" + resourceName,
            method: "GET",
            async: false,
            contentType: "application/json",
            success: function (data) {
                result = data;
            },
            error: function (error) {
                alert(error);
            }
        });

        return result;
    }
};