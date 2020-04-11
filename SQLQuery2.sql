create procedure AddEmployee(
@Name VARCHAR(50),
@empcode int,
@salary Money,
@Position varchar(100)

)
as
begin
insert into employee values(@Name,@empcode,@salary,@position);
end

create procedure Getemployee
as
begin
Select * from employee;
end

create procedure UpdateEmployee(
@id int,
@Name VARCHAR(50),
@empcode int,
@salary Money,
@Position varchar(100)

)
as
begin
Update employee set Name=@Name, empcode=@empcode, @salary=@salary, position=@Position where Id = @id;
end

create procedure DeleteEmp(
@id int
)
as
begin
Delete From employee where Id = @id;
end