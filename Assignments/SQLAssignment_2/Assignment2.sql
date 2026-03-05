use SQLAssignments
create table Customers(
customer_id INT primary key,
first_name varchar(30),
last_name varchar(30)
)
create table orders(
order_id int primary key,
customer_id int,
order_date date,
order_status int,
foreign key(customer_id) references Customers(customer_id)
)

insert into Customers(customer_id, first_name, last_name) values
(1,'akhil','akkineni'),
(2,'arjun','allu'),
(3,'rana','dabbubati')

insert into orders(order_id, customer_id,order_date,order_status) values
(101,1, '2024.01.10',1),
(102,2 ,'2024.01.12',4),
(103,1, '2024.01.15',2),
(104,3 ,'2024.01.18',1)

select c.first_name,c.last_name,o.order_id,o.order_date,o.order_status from
customers c inner join orders o 
on c.customer_id=o.customer_id
where o.order_status =1 or o.order_status =4
order by o.order_date desc;