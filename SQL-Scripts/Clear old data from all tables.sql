delete from `medistore manager`.customer_order where ID < 5000;
delete from `medistore manager`.order where ID < 5000;
delete from `medistore manager`.inventory_item where ID < 5000;
delete from `medistore manager`.supplier where Name != "test";
delete from `medistore manager`.person where ID < 5000;
delete from `medistore manager`.address where ID < 5000;
delete from `medistore manager`.user where ID < 5000;