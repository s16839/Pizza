-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2019-12-17 11:13:52.439

-- tables
-- Table: Admin
CREATE TABLE Admin (
    id_admin int  NOT NULL,
    name varchar(32)  NOT NULL,
    Order_id_order int  NOT NULL,
    CONSTRAINT Admin_pk PRIMARY KEY  (id_admin)
);

-- Table: Bread_type
CREATE TABLE Bread_type (
    id_bread_type int  NOT NULL,
    name varchar(32)  NOT NULL,
    price smallmoney  NOT NULL,
    CONSTRAINT Bread_type_pk PRIMARY KEY  (id_bread_type)
);

-- Table: Customer
CREATE TABLE Customer (
    id_customer int  NOT NULL,
    address varchar(32)  NOT NULL,
    CONSTRAINT Customer_pk PRIMARY KEY  (id_customer)
);

-- Table: Delivery_Man
CREATE TABLE Delivery_Man (
    id_delivery_man int  NOT NULL,
    name varchar(32)  NOT NULL,
    surname varchar(32)  NOT NULL,
    emp_number int  NOT NULL,
    CONSTRAINT Delivery_Man_pk PRIMARY KEY  (id_delivery_man)
);

-- Table: Ingredient
CREATE TABLE Ingredient (
    id_ingredient int  NOT NULL,
    name varchar(32)  NOT NULL,
    price smallmoney  NOT NULL,
    CONSTRAINT Ingredient_pk PRIMARY KEY  (id_ingredient)
);

-- Table: Ingredient_Set
CREATE TABLE Ingredient_Set (
    Pizza_id_pizza int  NOT NULL,
    Ingredient_id_ingredient int  NOT NULL,
    CONSTRAINT Ingredient_Set_pk PRIMARY KEY  (Pizza_id_pizza,Ingredient_id_ingredient)
);

-- Table: Order_
CREATE TABLE Order_ (
    id_order int  NOT NULL,
    date date  NOT NULL,
    time_ordered time(16)  NOT NULL,
    time_delivered time(16)  NOT NULL,
    order_status int  NOT NULL,
    total_price smallmoney  NOT NULL,
    Delivery_Man_id_delivery_man int  NOT NULL,
    Customer_id_customer int  NOT NULL,
    CONSTRAINT Order__pk PRIMARY KEY  (id_order)
);

-- Table: Pizza
CREATE TABLE Pizza (
    id_pizza int  NOT NULL,
    name varchar(32)  NOT NULL,
    is_customizable bit  NOT NULL,
    price smallmoney  NOT NULL,
    size varchar(32)  NOT NULL,
    discount smallmoney  NOT NULL,
    Bread_type_id_bread_type int  NOT NULL,
    Order_id_order int  NULL,
    is_vege bit  NOT NULL,
    is_spicy bit  NOT NULL,
    CONSTRAINT Pizza_pk PRIMARY KEY  (id_pizza)
);

-- foreign keys
-- Reference: Admin_Order (table: Admin)
ALTER TABLE Admin ADD CONSTRAINT Admin_Order
    FOREIGN KEY (Order_id_order)
    REFERENCES Order_ (id_order);

-- Reference: Ingredient_Set_Ingredient (table: Ingredient_Set)
ALTER TABLE Ingredient_Set ADD CONSTRAINT Ingredient_Set_Ingredient
    FOREIGN KEY (Ingredient_id_ingredient)
    REFERENCES Ingredient (id_ingredient);

-- Reference: Ingredient_Set_Pizza (table: Ingredient_Set)
ALTER TABLE Ingredient_Set ADD CONSTRAINT Ingredient_Set_Pizza
    FOREIGN KEY (Pizza_id_pizza)
    REFERENCES Pizza (id_pizza);

-- Reference: Order_Customer (table: Order_)
ALTER TABLE Order_ ADD CONSTRAINT Order_Customer
    FOREIGN KEY (Customer_id_customer)
    REFERENCES Customer (id_customer);

-- Reference: Order_Delivery_Man (table: Order_)
ALTER TABLE Order_ ADD CONSTRAINT Order_Delivery_Man
    FOREIGN KEY (Delivery_Man_id_delivery_man)
    REFERENCES Delivery_Man (id_delivery_man);

-- Reference: Pizza_Bread_type (table: Pizza)
ALTER TABLE Pizza ADD CONSTRAINT Pizza_Bread_type
    FOREIGN KEY (Bread_type_id_bread_type)
    REFERENCES Bread_type (id_bread_type);

-- Reference: Pizza_Order (table: Pizza)
ALTER TABLE Pizza ADD CONSTRAINT Pizza_Order
    FOREIGN KEY (Order_id_order)
    REFERENCES Order_ (id_order);

-- End of file.

