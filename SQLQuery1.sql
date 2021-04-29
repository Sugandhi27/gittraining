select * from authors
select * from publishers
select * from titles
select * from titleauthor
select * from sales

--1.Print city name and count of authors from every city
select city, count(au_id)author_count from authors group by city

--2.Print the authors who are not from the same city in which the publisher 'New Moon Books' is from
select au_fname, au_lname from authors where city in
(select city from titles where title != 'New Moon Books')

--3.Create a procedure that will take the author first name and last name and new price 
--The procedure should update the price of the books written by the author with the give name 
create proc proc_UpdatePrice(@fname varchar(50),
@lname varchar(50),@n_price varchar(20))
as
begin
update titles set price=@n_price where title_id in
(select title_id from titleauthor where au_id in 
(select au_id from authors where au_fname=@fname and au_lname=@lname))
end
exec proc_UpdatePrice 'Dean', 'Straight', '250'

--4.Create a function that will calculate tax for the sale of every book
create function fn_CalculateTaxSales(@quantity int)
returns float
as
begin
declare
@tax int
if(@quantity < 10)
set @tax=2
else if(@quantity>10 and @quantity<=20)
set @tax=5
else if(@quantity>20 and @quantity<=50)
set @tax=6
else
set @tax=7.5
return @tax
end

select qty,dbo. fn_CalculateTaxSales(qty) 'Tax' from sales