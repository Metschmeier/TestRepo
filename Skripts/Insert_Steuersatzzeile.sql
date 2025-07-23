select * from Steuersaetze

insert into Steuersaetze (SteuersatzInProzent, Prozentsatz)
values 
('10%', 10),
('0%', 0)



update Steuersaetze set SteuersatzInProzent = '0%' where SteuersatzzeileId = 3


delete from Steuersaetze where SteuersatzzeileId = 4