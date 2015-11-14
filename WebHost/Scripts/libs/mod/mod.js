define(["lib/rsvp/rsvp","jquery"], function (RSVP, $) {

    return {
        sendQuery: function (query) {

            var promise = new RSVP.Promise(function (resolve, reject) {
                var url = window.urlpreffix + "api/Cqrs/SendQuery";

                $.ajax({
                    type: 'POST',
                    url: url,
                    dataType: 'text',                    
                    cache: false,
                    data: "="+JSON.stringify(query),
                    success: function (data) {
                        var x =  $.parseJSON(data);
                        resolve(x);
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        reject(errorThrown);
                    }
                });


            });

            return promise;
        }
    }


});