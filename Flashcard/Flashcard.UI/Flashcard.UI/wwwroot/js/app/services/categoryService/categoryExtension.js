(function($) {

	var categoryService = new CategoryService();

	$.fn.onAddCatgory = function () {
		$(this).submit(function() {
			categoryService.addCategory();
			return false;
		});
	};

	/**
	 * Fetch categories from web api
	 */
	$.fn.onCategoryFetch = function() {
		categoryService.getCategories();
	};

	/**
	 * toogles adding category form
	 * @param {boolean} state state of visibility
	 */
	$.fn.onToggleForm = function (state) {
       
        $(this).click(function () {
            var $categoryForm = $("#category-form");
            var showBtnClass = "";
            var hideBtnClass = "";

            if (state === true) {
                $categoryForm.addClass("d-flex").removeClass("hidden");
                showBtnClass = "#hide-form";
                hideBtnClass = "#show-form";
            } else {
                $categoryForm.removeClass("d-flex").addClass("hidden");
                showBtnClass = "#show-form";
                hideBtnClass = "#hide-form";
            }

            $(showBtnClass).addClass("d-flex").removeClass("hidden");
            $(hideBtnClass).removeClass("d-flex").addClass("hidden");
        });
    };

    /**
     * Delete category
     */
    $.fn.onDeleteCategory = function() {

        $(this).on("click", ".delete-category", function () {

            if (confirm("Are you sure you want to delete this item. Action will be permanent.")) {

                var id = $(this).parent("div").parent("div").parent("li").attr("id");

                categoryService.deleteCategory(id, $(this));
            }

            return false;
        });

    };

} (jQuery));