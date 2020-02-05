var CategoryService = function() {
	baseService.call(this);
	this.url = this.webApiHostUrl + "Category";
};

/**
 * Add categories to html list
 * @param {Object<Category>} categories list of categories
 */
var createCategoryLink = function (categories) {

    $("#category-list li.active").remove();

    categories.forEach(function (category) {

		var el = $("#template").clone();
		el.attr("id", category.id)
            .removeClass("hidden")
            .addClass("active")
			.find("span")
			.text(category.name);

		$("#category-list").append(el);
	});
};

/**
 * Fetch categories from web api
 */
CategoryService.prototype.getCategories = function() {
	$.ajax({
		url: this.url,
		dataType: 'json',
		contentType: 'application/json',
		method: 'get',
		error: function (jqXHR) {
			$("#leftMenuErrorMessage").addErrorMessage('Error occours while fetching categories. ' + jqXHR.responseText);
		},
		success: function (categories, textStatus, jqXHR) {

			$("#leftMenuErrorMessage").removeErrorMessageDialog();

			createCategoryLink(categories);
		}
	});
};

/**
 * Add category
 */
CategoryService.prototype.addCategory = function() {

	var self = this;

	$.ajax({
		url: this.url,
		data: JSON.stringify({
			name: $("#categoryName").val()
		}),
		dataType: 'json',
		contentType: 'application/json',
		method: 'POST',
		error: function (jqXHR) {
			$("#leftMenuErrorMessage").addErrorMessage('Error occours while adding category. ' + jqXHR.responseText);
		},
		success: function () {
			$("#leftMenuErrorMessage").removeErrorMessageDialog();

			self.getCategories();
		}
	});

};

/**
 * Delete category
 * @param {any} id id of category 
 * @param {any} $link jquery element of delete link
 */
CategoryService.prototype.deleteCategory = function(id, $link) {

    var self = this;

    $link.prop("disabled", true);

    $.ajax({
        url: this.url + "/" + id,
        dataType: "json",
        method: "delete",
        contentType: 'application/json',
        error: function(jqXHR) {
            $("#leftMenuErrorMessage").addErrorMessage('Error occours while adding category. ' + jqXHR.responseText);

            $link.prop("disabled", false);
        },
        success: function() {
            $("#leftMenuErrorMessage").removeErrorMessageDialog();
            
            self.getCategories();
        }

    });
};