SELECT r.Name AS RoleName
FROM AspNetRoles r
JOIN AspNetUserRoles ur ON ur.RoleId = r.Id
JOIN AspNetUsers u ON u.Id = ur.UserId
WHERE u.UserName = 'tommy@domain.com'
