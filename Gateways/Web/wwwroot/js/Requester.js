const DEFAULT_HEADERS = {
    GET: {

    },
    POST: {
        'Content-Type': 'application/json',
    },
};

const METHODS = {
    GET: 'GET',
    POST: 'POST',
};

const requester = {
    get: function (uri) {
        return this._request(uri);
    },
    post: function (uri, options) {
        return this._request(uri, METHODS.POST, options);
    },
    _request: function (uri, method = METHODS.GET, options = { }) {
        const headers = {
            ...DEFAULT_HEADERS[method],
            ...options.headers,
        };
        const body = options.body && JSON.stringify(options.body);

        return fetch(uri, { ...options, headers, body })
            .then(res => res.json())
            .then(data => {
                if (data.error) {
                    exceptionHandler.handleResponse(data.error);
                }

                return data;
            });
    }
}