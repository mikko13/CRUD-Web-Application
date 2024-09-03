app.service("CRUDService", function ($http) {
    this.getAll = function () {
        return $http.get("/Home/read");
    };

    this.create = function (person) {
        return $http.post("/Home/create", person);
    };

    this.update = function (person) {
        return $http.post("/Home/update", person);
    };

    this.delete = function (id) {
        return $http.post("/Home/delete", { id: id });
    };
});
