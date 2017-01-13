create database announcements;

use announcements;

create table t_announcements (
	id int auto_increment primary key,
	content varchar(2500) not null,
	start_date datetime,
	end_date datetime,
	created_date timestamp
)
