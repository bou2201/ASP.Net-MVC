-- CREATE DATABASE 

drop database if exists Menswear_db;

create database Menswear_db;

use Menswear_db;


-- CREATE & GRANT FOR USER 


create user if not exists 'admin'@'localhost' identified by 'admin2002';
grant all on Menswear_db.* to 'admin'@'localhost';


-- CREATE TABLE


create table Users (
	user_id int auto_increment primary key,
	user_username varchar(50) NOT NULL,
	user_password varchar(255) NOT NULL,
	user_email varchar(255) NOT NULL,
	user_phone varchar(15) NOT NULL
);
        
create table Customers(
	customer_id int auto_increment primary key,
    customer_name varchar(100) not null,
    customer_phone varchar(20) not null,
    customer_address varchar(100) not null
);

create table Categories (
	category_id int auto_increment primary key,
	category_name varchar(50) NOT NULL
);

create table Colors (
	color_id int auto_increment primary key,
	color_name varchar(50) NOT NULL
);

create table Sizes (
	size_id int auto_increment primary key,
	size_name varchar(50) NOT NULL
);

create table Products (
	product_id int auto_increment primary key,
	product_name varchar(50) NOT NULL,
	product_description varchar(600) NOT NULL,
	product_brand varchar(50) NOT NULL,
	product_material varchar(50) NOT NULL,
	product_price decimal(10,3) NOT NULL,
	product_image varchar(255) NOT NULL,
	category_id int,
	constraint fk_category_id foreign key(category_id) references Categories(category_id)
) ;

create table ProductDetails (
	product_id int,
	size_id int,
	color_id int,
	quantity int not null,
	constraint pk_productDetail_product primary key(product_id, size_id, color_id),
	constraint fk_productDetail_product foreign key(product_id) references Products(product_id),
    constraint fk_productDetail_size foreign key(size_id) references Sizes(size_id),
    constraint fk_productDetail_color foreign key(color_id) references Colors(color_id)
) ;

create table Invoices (
	invoice_id int auto_increment primary key,
	invoice_date datetime default now() NOT NULL,
	invoice_status varchar(50) NOT NULL,
	user_id int,
    customer_id int,
    constraint fk_user_name foreign key(user_id) references Users(user_id),
	constraint fk_customer_name foreign key(customer_id) references Customers(customer_id)
);

create table InvoiceDetails (
	invoice_id int,
	product_id int,
    constraint pk_invoiceDetail_invoice primary key(invoice_id, product_id),
    constraint fk_invoiceDetail_invoice foreign key(invoice_id) references Invoices(invoice_id),
    constraint fk_invoiceDetail_product foreign key(product_id) references Products(product_id),
	total_due decimal(5,2) NOT NULL,
	quantity int NOT NULL
);

select * from Products where Products.product_id = 1;
-- INSERT INTO TABLE


insert into Users (user_id, user_username, user_password, user_email, user_phone)
	values  (1, 'Chuc', 'e10adc3949ba59abbe56e057f20f883e', 'lamchuc123456@gmail.com', '0123456');
						-- 123456
            
select * from Users;

insert into Categories (category_id, category_name)
 values (1, 'Shirts'),
		(2, 'Pants'),
		(3, 'Hats'),
		(4, 'Watches'),
		(5, 'Rings'),
		(6, 'Glasses'),
		(7, 'Bags');

select * from Categories;

insert into Colors (color_id, color_name) 
values (1, 'White'),
		(2, 'Black'),
		(3, 'Red'),
		(4, 'Blue'),
		(5, 'Green'),
		(6, 'Gray'),
		(7, 'Pink');

select * from Colors;

insert into Sizes (size_id, size_name)
values (1, 'S'),
		(2, 'M'),
		(3, 'L'),
		(4, 'XL'),
		(5, 'XXL'),
		(6, 'Oversize');
        
select * from Sizes;

insert into Products (product_id, product_name, product_description, product_brand, product_material, product_price, product_image, category_id)
values 
	(1, 'Oversize Coach Jacket', 'Vest collar, soft, masculine, luxurious silk material', 'ONTOP', 'Cotton', '249.000', 'https://imgur.com/Rwz9wr8', 1),
	(2, 'Hoodie Zip Xiao', 'The slim-fit form fits snugly and flatters the figure', 'DAVIES', 'Cotton, Fabric', '499.000', 'https://imgur.com/ayEKsgU', 1),
	(3, 'Oversize Wash Tee - 2021', 'The shirt has detailed leather pockets on the chest to create accents', 'COOLMATE', 'Cotton 98%, Polyester 2%', '299.000', 'https://imgur.com/t1TEhiU', 1),
	(4, 'Coduroy Maracon Jacket', 'Medium stretch, durable quality no need to last long', 'SSSTUTTER', 'Cotton Fleece, Melton Wool', '499.000', 'https://imgur.com/D1rDNCZ', 1),
	(5, 'Coduroy Baggy Pants', 'Shirt used for activities, gym or daily wear', 'COOLMATE', 'Fabric', '259.000', 'https://imgur.com/6w7gK0R', 2),
	(6, 'Polo Remember', 'Super soft fabric, this fitted shirt features a button-down', 'ULZZANG', 'Cotton', '299.000', '', 1),
	(7, 'Classic Portrait', '180gsm round spun cotton t-shirt, round collar, Jersey neckband', 'SSSTUTTER', 'Mixed Wool, Cotton', '229.000', '', 1),
	(8, 'Coduroy Choco Shirt', 'Short-sleeve round-neck T-shirt with good absorbency to bring comfort', 'COOLMATE', 'Cotton, Fabric', '319.000', '', 1),
	(9, 'MeetingYou Tee', 'Shirt used for activities, gym or daily wear', 'COOLMATE', 'Cotton, Fabric', '249.000', '', 1),
	(10, 'J.Wick Portrait Tee', 'Short-sleeved round-neck t-shirt brings youthfulness and dynamism', 'ONTOP', 'Cotton', '299.000', '', 1),
	(11, 'Overthinking Tee', 'Breathable material shirt, collar with buttons all around ', 'SSSTUTTER', 'Cotton 98%, Polyester 2%', '299.000', '', 1),
	(12, 'DoWhatYouWant Tee', 'A sleeveless tank top with Nirvana print on the chest', 'COCCACH', 'Cotton', '229.000', '', 1),
	(13, 'Oversize Wash Tee', 'Round neck short sleeve top, designed with high quality soft', 'COCCACH', 'Mixed Wool, Cotton', '249.000', '', 1),
	(14, 'Coduroy Varsity Restock', 'Round neck short sleeve top, designed with high quality soft', 'DOCMENSWEAR', 'Cotton, Fabric', '449.000', '', 1),
	(15, 'Dane K Bag', 'Collared shirt, simple design, wide form, shapes, concealer', 'ZARA', 'Simili', '349.000', '', 7),
	(16, 'FF Cheese Bag', 'The jacket is made of soft, breathable and lightweight fabric', 'H2T', 'Simili, Fabric', '349.000', '', 7),
	(17, 'FF Butter Bag', 'Easy to operate, and easy to combine with a variety of clothes', 'TORANO', 'Tricot, Micro Polyester', '399.000', '', 7),
	(18, 'Oversize Zip Hoodie', 'Flat front and elasticated back, side seam pockets', 'COCCACH', 'Fabric, Cotton', '459.000', '', 1),
	(19, 'FF Zip Hoodie - Brown', 'The pants are super durable, super soft', '5THEWAY', 'Kaki, Cotton', '699.000', '', 1),
	(20, 'FF Fabric Short Pants', 'The pants are designed with two-pipe, heat-insulating', '5THEWAY', 'Kaki, Cotton', '249.000', '', 2),
	(21, 'FF Zip Hoodie - Grey', 'The pants are designed to be soft with two tubes, good insulation', '5THEWAY', 'Cotton', '699.000', '', 1),
	(22, 'FF Suede Zip Hoodie', 'Pants with elastic waistband, size zip pocket and gold', 'ONTOP', 'Suede', '559.000', '', 1),
	(23, 'Fleece Jacket', 'Blue pants. Low floor. Fading, patchy, and painful throughout', 'COOLMATE', 'Velvet Fabric', '699.000', '', 1),
	(24, 'FF Oversize Reflective Cookie Jacket', 'Garments are dyed & washed with enzymes', 'DIRTY COINS', 'Cotton, Kaki', '459.000', '', 1),
	(25, 'Polo Saigon Classic', 'Zip/button front front, high waist for a snug fit', 'SSSTUTTER', 'Cotton', '249.000', '', 1),
	(26, 'Overthinking Super Tee', '', 'ONTOP', 'Cotton 98%, Polyester 2%', '299.000', '', 1),
	(27, 'FF Coduroy Baggy Pants', '', 'ONTOP', 'Cotton, Fabric', '319.000', '', 2);

select * from Products;


insert ignore into ProductDetails (product_id, size_id, color_id, quantity) 
values  (1, 2, 1, 10), (1, 3, 2, 10), (1, 4, 6, 10),
		(2, 2, 1, 10), (2, 3, 2, 10), (2, 4, 6, 10),
		(3, 2, 1, 10), (8, 3, 2, 10), (9, 4, 6, 10),
        (4, 2, 1, 10), (11, 3, 2, 10), (12, 4, 6, 10),
		(5, 2, 6, 10), (14, 3, 2, 10), (15, 4, 1, 10),
        (6, 2, 6, 10), (2, 3, 2, 10), (3, 4, 1, 10),
		(7, 2, 6, 10), (5, 3, 2, 10), (6, 4, 1, 10),
		(8, 2, 6, 10), (8, 3, 2, 10), (9, 4, 1, 10),
        (9, 2, 1, 10), (11, 3, 6, 10), (12, 4, 2, 10),
		(10, 3, 1, 10), (14, 4, 6, 10), (15, 5, 2, 10),
        (11, 3, 1, 10), (2, 4, 2, 10), (3, 5, 6, 10),
		(12, 3, 1, 10), (5, 4, 2, 10), (6, 5, 3, 10),
		(13, 3, 2, 10), (8, 4, 1, 10), (9, 5, 3, 10),
        (14, 3, 5, 10), (11, 4, 4, 10), (12, 5, 1, 10),
		(15, 3, 3, 10), (14, 4, 1, 10), (15, 5, 6, 10),
        (16, 3, 1, 10), (2, 4, 2, 10), (3, 5, 5, 10),
		(17, 3, 6, 10), (5, 4, 6, 10), (6, 5, 5, 10),
		(18, 1, 2, 10), (8, 2, 1, 10), (9, 3, 3, 10),
        (19, 1, 5, 10), (11, 2, 4, 10), (12, 3, 1, 10),
		(20, 1, 3, 10), (14, 2, 1, 10), (15, 3, 6, 10);
        
select * from ProductDetails;
                        
delimiter $$
create trigger tg_before_insert before insert
	on ProductDetails for each row
    begin
		if new.quantity < 0 then
            signal sqlstate '45001' set message_text = 'tg_before_insert: amount must > 0';
        end if;
    end $$
delimiter ;

delimiter $$
create trigger tg_CheckAmount
	before update on ProductDetails
	for each row
	begin
		if new.quantity < 0 then
            signal sqlstate '45001' set message_text = 'tg_CheckAmount: amount must > 0';
        end if;
    end $$
delimiter ;

delimiter $$
create procedure sp_createCustomer(IN customerName varchar(100), IN customerPhone varchar(20), IN customerAddress varchar(100),OUT customerId int)
begin
	insert into Customers(customer_name, customer_phone, customer_address) values (customerName, customerPhone, customerAddress); 
    select max(customer_id) into customerId from Customers;
end $$
delimiter ;

