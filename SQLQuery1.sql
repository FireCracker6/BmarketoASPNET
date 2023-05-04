SELECT Tags.TagName
FROM Tags
INNER JOIN ProductTags ON ProductTags.TagsId = Tags.Id
INNER JOIN Products ON Products.Id = ProductTags.ProductsEntityId
WHERE Products.Id = 1018;
