// <copyright file="WordServiceTest.cs" username="Krzysztof Maraszkiewicz">
//    Copyright (c) 2018 Krzysztof Maraszkiewicz
// </copyright>

using System;
using DataModel.Enums;
using FluentAssertions;
using Implementations.Exceptions;
using ImplementationsUnitTest.Enums;
using ImplementationsUnitTest.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImplementationsUnitTest.WordMgt
{
	/// <summary>
	/// WordService unit tests class.
	/// </summary>
	[TestClass]
	public class WordServiceTest
	{
		/// <summary>
		/// The word service helper
		/// </summary>
		private readonly WordServiceHelper _wordServiceHelper;

		/// <summary>
		/// Initializes a new instance of the <see cref="WordServiceTest"/> class.
		/// </summary>
		public WordServiceTest()
		{
			_wordServiceHelper = new WordServiceHelper();
		}

		/// <summary>
		/// Gets the parents with children.
		/// </summary>
		[TestMethod]
		public void GetParentsWithChildrenTest()
		{
			_wordServiceHelper.Initialize(false);
			var items = _wordServiceHelper.WordService.GetAll(WordItemsType.ParentsWithChildren);
			items.Should().BeEquivalentTo(_wordServiceHelper.ParentsWithChildrenWordsModel);
		}

		/// <summary>
		/// Gets the child with parents.
		/// </summary>
		[TestMethod]
		public void GetChildWithParentsTest()
		{
			_wordServiceHelper.Initialize(false);
			var items = _wordServiceHelper.WordService.GetAll(WordItemsType.ChildWithParents);
			items.Should().BeEquivalentTo(_wordServiceHelper.ChildWithParentsWordsModel);
		}

		/// <summary>
		/// Gets the parents with children from empty collection.
		/// </summary>
		[TestMethod]
		public void GetParentsWithChildrenFromEmptyCollectionTest()
		{
			_wordServiceHelper.Initialize(false, true);
			var items = _wordServiceHelper.WordService.GetAll(WordItemsType.ParentsWithChildren);
			items.Should().BeEmpty();
		}

		/// <summary>
		/// Gets the child with parents from empty collection.
		/// </summary>
		[TestMethod]
		public void GetChildWithParentsFromEmptyCollectionTest()
		{
			_wordServiceHelper.Initialize(false, true);

			var items = _wordServiceHelper.WordService.GetAll(WordItemsType.ChildWithParents);
			items.Should().BeEmpty();
		}

		/// <summary>
		/// Adds the valid date test.
		/// </summary>
		[TestMethod]
		public void AddValidDateTest()
		{
			_wordServiceHelper.Initialize();

			var addAsync = _wordServiceHelper.WordService.AddAsync(_wordServiceHelper.GetWordModel());
			addAsync.Wait();
		}

		/// <summary>
		/// Adds the date with category no exists test.
		/// </summary>
		[TestMethod]
		public void AddDateWithCategoryNoExistsTest()
		{
			_wordServiceHelper.Initialize();

			Action addFunction = () =>
			{
				var addAsync =
					_wordServiceHelper.WordService.AddAsync(
						_wordServiceHelper.GetWordModel(WordModelDataType.CategoryNoExists));

				addAsync.Wait();
			};

			addFunction.Should().Throw<NotFoundException>();
		}

		/// <summary>
		/// Adds the date with category no exists test.
		/// </summary>
		[TestMethod]
		public void AddDataWithEmptyTranslatedWordsCollectionTest()
		{
			_wordServiceHelper.Initialize();

			Action addFunction = () =>
			{
				var addAsync =
					_wordServiceHelper.WordService.AddAsync(
						_wordServiceHelper.GetWordModel(WordModelDataType.EmptyTranslatedWordsCollection));

				addAsync.Wait();
			};

			addFunction.Should().Throw<BadRequestException>();
		}

		/// <summary>
		/// Adds the date with empty original value test.
		/// </summary>
		[TestMethod]
		public void AddDateWithEmptyOriginalValueTest()
		{
			_wordServiceHelper.Initialize();

			Action addFunction = () =>
			{
				var addAsync =
					_wordServiceHelper.WordService.AddAsync(
						_wordServiceHelper.GetWordModel(WordModelDataType.EmptyOriginalValue));

				addAsync.Wait();
			};

			addFunction.Should().Throw<BadRequestException>();
		}

		/// <summary>
		/// Adds the date with original value exists test.
		/// </summary>
		[TestMethod]
		public void AddDateWithOriginalValueExistsTest()
		{
			_wordServiceHelper.Initialize();

			Action addFunction = () =>
			{
				var addAsync =
					_wordServiceHelper.WordService.AddAsync(
						_wordServiceHelper.GetWordModel(WordModelDataType.OriginalValueExists));

				addAsync.Wait();
			};

			addFunction.Should().Throw<BadRequestException>();
		}

		/// <summary>
		/// Deletes the item by valid identifier test.
		/// </summary>
		[TestMethod]
		public void DeleteItemByValidIdTest()
		{
			_wordServiceHelper.Initialize();

			var deleteAsync =
				_wordServiceHelper.WordService.DeleteAsync(1);

			deleteAsync.Wait();
		}

		/// <summary>
		/// Deletes the no exists item test.
		/// </summary>
		[TestMethod]
		public void DeleteNoExistsItemTest()
		{
			_wordServiceHelper.Initialize();

			Action deleteAction = () =>
			{
				var deleteAsync =
					_wordServiceHelper.WordService.DeleteAsync(999);

				deleteAsync.Wait();
			};
		
			deleteAction.Should().Throw<NotFoundException>();
		}

		/// <summary>
		/// Deletes the item by valid identifier test.
		/// </summary>
		[TestMethod]
		public void UpdateValidDataTest()
		{
			_wordServiceHelper.Initialize();

			var updateAsync =
				_wordServiceHelper.WordService.UpdateAsync(
					_wordServiceHelper.GetWordModel(WordModelDataType.UpdatingValidData));

			updateAsync.Wait();
		}

		/// <summary>
		/// Updates the no exist item test.
		/// </summary>
		[TestMethod]
		public void UpdateNoExistItemTest()
		{
			_wordServiceHelper.Initialize();

			Action updateAction = () =>
			{
				var updateAsync =
					_wordServiceHelper.WordService.UpdateAsync(
						_wordServiceHelper.GetWordModel(WordModelDataType.WordNoExists));

				updateAsync.Wait();
			};

			updateAction.Should().Throw<NotFoundException>();
		}

		/// <summary>
		/// Updates the when category no exists test.
		/// </summary>
		[TestMethod]
		public void UpdateWhenCategoryNoExistsTest()
		{
			_wordServiceHelper.Initialize();

			Action updateAction = () =>
			{
				var updateAsync =
					_wordServiceHelper.WordService.UpdateAsync(
						_wordServiceHelper.GetWordModel(WordModelDataType.CategoryNoExists));

				updateAsync.Wait();
			};

			updateAction.Should().Throw<NotFoundException>();
		}

		/// <summary>
		/// Updates the when original value exists test.
		/// </summary>
		[TestMethod]
		public void UpdateWhenOriginalValueExistsTest()
		{
			_wordServiceHelper.Initialize();

			Action updateAction = () =>
			{
				var updateAsync =
					_wordServiceHelper.WordService.UpdateAsync(
						_wordServiceHelper.GetWordModel(WordModelDataType.OriginalValueExists));

				updateAsync.Wait();
			};

			updateAction.Should().Throw<BadRequestException>();
		}

		/// <summary>
		/// Updates the when empty translated words collection test.
		/// </summary>
		[TestMethod]
		public void UpdateWhenEmptyTranslatedWordsCollectionTest()
		{
			_wordServiceHelper.Initialize();

			Action updateAction = () =>
			{
				var updateAsync =
					_wordServiceHelper.WordService.UpdateAsync(
						_wordServiceHelper.GetWordModel(WordModelDataType.EmptyTranslatedWordsCollection));

				updateAsync.Wait();
			};

			updateAction.Should().Throw<BadRequestException>();
		}
	}
}