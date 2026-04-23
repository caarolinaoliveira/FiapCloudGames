*A FIAP Cloud Games (FCG) *
**será uma plataforma de venda de jogos
digitais e gestão de servidores para partidas online. ** 



http://localhost:5101/swagger/index.html 





SELECT
    u.Id        AS UserId,
    u.Email,
    r.Id        AS RoleId,
    r.Name      AS RoleName
FROM AspNetUsers u
JOIN AspNetUserRoles ur ON u.Id = ur.UserId
JOIN AspNetRoles r      ON r.Id = ur.RoleId; 





MIGRATIONS 
dotnet ef migrations add AjusteIdentityApplicationUser   --startup-project ../FCG.Presentation

dotnet ef database update  --startup-project ../FCG.Presentation

