select Department,a.DepartmentId,b.DepartmentName 
from [employes] a inner join Department b 
on a.DepartmentId = b.DepartmentId