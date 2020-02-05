/**
 * @author Izabela Maraszkiewicz IT
 */

/**
 * Inherits parent class with child class
 * @param {any} child
 * @param {any} parent
 */
function inherits(child, parent) {
	var f = new Function;
	f.prototype = parent.prototype;
	f.prototype.constructor = parent;
	child.prototype = new f;
	child.prototype.constructor = child;
}

/**
 * 
 * @param {string} value
 */
function isNullOrEmptyEmpty(value) {

	return value === undefined || value.trim() === '';

}