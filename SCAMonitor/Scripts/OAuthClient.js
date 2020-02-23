var OAuthClient = function Client(urlToken) {
    this.urlToken = urlToken;
    this.authClient = null;

    this._setupAuth();
}

OAuthClient.prototype._login = function _login() {
    var self = this;

    $.ajax({
        url: self.urlToken,
        method: "POST",
        data: {
            grant_type: "password",
            username: "SCA",
            password: "129a8c68-91b9-4039-9787-da1bede81a9f"
        },
        statusCode: {
            200: function (response) {
                if (response.access_token === undefined) {
                    alert('Something went wrong');
                } else {
                    self.authClient.login(response.access_token, response.expires_in);
                }
            },
            401: function () {
                alert('Login failed');
            }
        }
    });
}

OAuthClient.prototype._logout = function _logout() {
    this.authClient.logout();
}

OAuthClient.prototype._setupAuth = function _setupAuth() {
    var self = this;

    this.authClient = new jqOAuth({
        events: {
            login: function () {
            },
            logout: function () {
            },
            tokenExpiration: function () {
                return $.post(self.urlToken).success(function (response) {
                    self.authClient.setAccessToken(response.accessToken, response.accessTokenExpiration);
                });
            }
        }
    });
}

