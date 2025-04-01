ALTER TABLE `medistore manager`.`user` 
ADD COLUMN `Deleted` TINYINT(1) NOT NULL DEFAULT '0' ;

ALTER TABLE `medistore manager`.`address` 
ADD COLUMN `Deleted` TINYINT(1) NOT NULL DEFAULT '0' ;

ALTER TABLE `medistore manager`.`person` 
ADD COLUMN `Deleted` TINYINT(1) NOT NULL DEFAULT '0' ;

ALTER TABLE `medistore manager`.`supplier` 
ADD COLUMN `Deleted` TINYINT(1) NOT NULL DEFAULT '0' ;

ALTER TABLE `medistore manager`.`inventory_item` 
ADD COLUMN `Deleted` TINYINT(1) NOT NULL DEFAULT '0' ;

ALTER TABLE `medistore manager`.`order` 
ADD COLUMN `Deleted` TINYINT(1) NOT NULL DEFAULT '0' ;

ALTER TABLE `medistore manager`.`customer_order` 
ADD COLUMN `Deleted` TINYINT(1) NOT NULL DEFAULT '0' ;