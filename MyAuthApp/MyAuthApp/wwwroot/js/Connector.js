var connector = function () {

    return {

        Post: function (url, data, callback) {
            var urlgs = window.location.href
            var arrgs = urlgs.split("/");
            var urlResgs = arrgs[0] + "//" + arrgs[2]

            var jqxhr = $.post(urlResgs + url, data, function (response) {


                if (response.isSuccess) {
                    if (response.messageShow) {
                        iziToast.success({
                            title: 'OK',
                            message: response.message,
                            timeout: 10000,
                            position: 'center',
                            animateInside: true,
                            drag: true,
                            theme: 'light'
                        });
                    }
                    callback(response.result);
                }
                else {
                    iziToast.error({
                        title: 'Error',
                        message: response.message,
                        timeout: 10000,
                        position: 'center',
                        animateInside: true,
                        drag: true,
                        theme: 'light'
                    });
                    hideLoader();
                }
            }).done(function () { })
                .fail(function () {
                    iziToast.error({
                        title: 'Error',
                        message: "Error in processing request",
                        timeout: 10000,
                        position: 'center',
                        animateInside: true,
                        drag: true,
                        theme: 'light'
                    });
                }).always(function () { })

        },
        Get: function (url, callback) {

            var urlgs = window.location.href
            var arrgs = urlgs.split("/");
            var urlResgs = arrgs[0] + "//" + arrgs[2]

            var jqxhr = $.get(urlResgs + url, function (res) {
                if (res.isSuccess) {
                    callback(res.result);
                } else {
                    iziToast.error({
                        title: 'Error',
                        message: res.message,
                        timeout: 10000,
                        position: 'center',
                        animateInside: true,
                        drag: true,
                        theme: 'light'
                    });
                    hideLoader();
                }

            }).done(function () {
            }).fail(function (error) { }).always(function () { })
        }
    }
}();