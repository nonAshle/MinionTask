-- утилиты
drop schema public cascade

create schema public 

--для норм времени
ALTER DATABASE "DailyPlanner" SET timezone TO 'Europe/Moscow';

drop table "Request" cascade
drop table "List service" cascade

SHOW ALL;

SELECT version();

select config;

CREATE INDEX IF NOT EXISTS "idx_activityhistory_log_id" ON "Activity History" ("ID log");
CREATE INDEX IF NOT EXISTS "idx_archivalrequest_id" ON "Archival request" ("ID request");
CREATE INDEX IF NOT EXISTS "idx_request_worker_id" ON "Request" ("Applicant’s id");
CREATE INDEX IF NOT EXISTS "idx_request_company_id" ON "Request" ("ID company");
CREATE INDEX IF NOT EXISTS "idx_request_service_id" ON "Request" ("ID service");
CREATE INDEX IF NOT EXISTS "idx_request_department_id" ON "Request" ("ID department");
CREATE INDEX IF NOT EXISTS "idx_request_equipment_id" ON "Request" ("ID equipment");
CREATE INDEX IF NOT EXISTS "idx_request_requiredservice_id" ON "Request" ("ID required service");

---------------------------------------------------------------------------------------------------------------------------------------

--основная структура

create table "List of companies" (
"ID company" serial primary key,
"Name company" varchar(40) not null,
"Description company" varchar(300)
);

create table "List of services" (
"ID company" integer references "List of companies"("ID company") on delete cascade,
"ID service" serial primary key,
"Name service" varchar(50) not null,
"Description service" varchar(300)
);

create table "List of departments" (
"ID service" integer references "List of services"("ID service") on delete cascade,
"ID department" serial primary key,
"Name department" varchar(50) not null,
"Description department" varchar(300)
);

create table "List of workers" (
"ID department" integer references "List of departments" ("ID department") on delete cascade,
"ID worker" serial primary key,
"Full name worker" varchar(80) not null,
"Worker location" varchar(20) not null,
"Worker room" varchar(10) not null,
"Worker contact phone" varchar(12) not null
);

create table "List of equipment" (
"ID equipment" serial primary key,
"Name equipment" varchar(50) not null,
"Description equipment" varchar(300)
);

create table "Employee equipment" (
"ID worker" integer references "List of workers"("ID worker") on delete cascade,
"ID equipment" integer references "List of equipment"("ID equipment") on delete cascade,
"Inventory number equipment" serial primary key
);

create table "List of workers PC" (
"ID worker" integer references "List of workers" ("ID worker") on delete cascade,
"Full name worker" varchar(80),
"Inventory number" integer references "Employee equipment" ("Inventory number equipment") on delete cascade,
"RDP author PC" varchar(15) not null
);

create table "List of workers accounts" (
"ID worker" integer references "List of workers" ("ID worker") on delete cascade,
"ID account" serial primary key,
"Login" varchar(25) unique not null,
"Password" varchar(30) not null,
"Group privilege" varchar(25) not null
);

create table "List of required service category" (
"ID required service category" serial primary key,
"ID department" integer references "List of departments" ("ID department") on delete cascade,
"Name required service category" varchar(100) not null unique,
"Description required service category" varchar(300)
);

create table "List of required services" (
"ID required service" serial primary key,
"ID required service category" integer references "List of required service category" ("ID required service category") on delete cascade,
"ID equipment" integer references "List of equipment" ("ID equipment") on delete cascade,
"Name required service" varchar(100) not null unique,
"Description required service" varchar(300)
);

create table "Possible status request" (
"ID status request" serial primary key,
"Status name" varchar(30) not null unique,
"Description status" varchar(300)
);

create table "Request" (
"ID request" serial primary key,
"Author" varchar(80),
"ID company" integer references "List of companies" ("ID company") on delete cascade,
"Applicant’s company" varchar(40),
"ID service" integer references "List of services" ("ID service") on delete cascade,
"Applicant’s service" varchar(50),
"ID department" integer references "List of departments" ("ID department") on delete cascade,
"Applicant’s department" varchar(50),
"Applicant’s id" integer references "List of workers" ("ID worker") on delete cascade ,
"Applicant’s full name" varchar(80),
"Applicant’s location" varchar(20),
"Applicant’s room" varchar(10),
"Applicant’s contact phone" varchar(12),
"Inventory number subject" integer references "Employee equipment" ("Inventory number equipment") on delete cascade,
"ID equipment" integer references "List of equipment" ("ID equipment"),
"Subject of the application" varchar(100),
"ID required service" integer references "List of required services" ("ID required service") on delete cascade,
"Required service" varchar(100),
"Inventory number" integer,
"RDP author PC" varchar(15),
"Date of request submission" timestamp not null,
"Last modified date" timestamp not null,
"Description request" varchar(300),
"ID status request" integer references "Possible status request" ("ID status request") on delete cascade,
"Request status" varchar(30),
"Technical staff response" varchar(300)
);

create table "Archival request" (
"ID request" integer,
"Author" varchar(80),
"ID company" integer ,
"Applicant’s company" varchar(40),
"ID service" integer,
"Applicant’s service" varchar(50),
"ID department" integer,
"Applicant’s department" varchar(50),
"Applicant’s id" integer,
"Applicant’s full name" varchar(80),
"Applicant’s location" varchar(20),
"Applicant’s room" varchar(10),
"Applicant’s contact phone" varchar(12),
"Inventory number subject" integer,
"ID equipment" integer,
"Subject of the application" varchar(100),
"ID required service" integer,
"Required service" varchar(100),
"Inventory number" integer,
"RDP author PC" varchar(15),
"Date of beginning of archive" timestamp not null,
"Description request" varchar(300),
"ID status request" integer,
"Request status" varchar(30),
"Technical staff response" varchar(300), 

PRIMARY KEY ("ID request", "Date of beginning of archive")
) PARTITION BY RANGE ("Date of beginning of archive");


create table "Activity History" (
"ID log" serial,
"ID request" integer,
"ID worker" integer,
"Action type" varchar(6) not null,
"Log description" varchar(750) not null,
"Date change" timestamp,

PRIMARY KEY ("ID log", "Date change")
) PARTITION BY RANGE ("Date change"); 

-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--для проги sql запросы

select "Group privilege"
from "List of workers accounts"
where "Login" = 'Denis' and "Password" = 'Password_Denisa';

select 
	r."ID request",
	r."Required service",
	r."Author",
	r."Last modified date",
	r."Request status"
from "List of workers accounts" a
join "Request" r on r."Applicant’s id" = a."ID worker"
where a."Login" = Denis
order by r."Last modified date" desc;

select
	"ID request",
	"Author",
	"Applicant’s company",
	"Applicant’s service",
	"Applicant’s department",
	"Applicant’s full name",
	"Applicant’s location",
	"Applicant’s room",
	"Applicant’s contact phone",
	"Subject of the application",
	"Required service",
	"RDP author PC",
	"Date of request submission",
	"Last modified date",
	"Request status",
	"Description request"
from "Request"
where "ID request" = 1;

select s."Name required service" 
from "List of equipment" e
join "List of required services" s on s."ID equipment" = e."ID equipment"
where e."Name equipment" = 'Персональный компьютер';

select "Status name"
from "Possible status request";

select 
	r."ID request",
	r."Required service",
	r."Author",
	r."Last modified date",
	r."Request status"
from "Request" r
join "List of required services" rs on rs."ID required service" = r."ID required service"
join "List of required service category" sc on sc."ID required service category"	 = rs."ID required service category"
join "List of departments" d on d."ID department" = sc."ID department"
join "List of workers accounts" a on a."Login" = 'Maksim'
join "List of workers" w on w."ID worker" = a."ID worker"
where d."ID department" = w."ID department" and r."Request status" = 'Ожидание'
order by r."Last modified date" desc;


select 
	e."Name equipment" 
from "List of equipment" e 
join "Employee equipment" ee on ee."ID equipment" = e."ID equipment" 
join "List of workers accounts" wa on wa."ID worker" = ee."ID worker" 
where wa."Login" = 'Maksim' order by ee."ID equipment" asc;

select rs."Name required service" 
from "List of required services" rs 
join "List of equipment" e on e."ID equipment" = rs."ID equipment" 
where e."Name equipment" = 'Персональный компьютер' order by rs."Name required service" asc;


select "Full name worker" 
from "List of workers" 
where "ID worker" = 2;

select e."Name equipment" || ' | ID:' || ee."Inventory number equipment" 
from "List of equipment" e 
join "Employee equipment" ee on ee."ID equipment" = e."ID equipment" 
join "List of workers accounts" wa on wa."ID worker" = ee."ID worker" 
where wa."Login" = 'Lexa'
order by ee."ID equipment" asc;

delete from "Request"
where "Date of request submission" < now();

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--заполнялка базовых данных
insert into "List of companies" ("Name company", "Description company") values
('Метрополитен', 'Первая компания');


insert into "List of services" ("ID company", "Name service", "Description service") values
(1, 'Служба 1', 'Описание для первой службы'),
(1, 'Служба 2', 'Описание для второй службы'),
(1, 'Служба 3', 'Описание');


insert into "List of departments" ("ID service", "Name department","Description department") values 
(1,'Отдел 1', 'Описание для отдела 1 службы 1'),
(1, 'Отдел 2', 'Описание для отдела 2 службы 1'),
(2, 'Отдел 1', 'Описание для отдела 1 службы 2'),
(2, 'Отдел 2', 'Описание для отдела 2 службы 2'),
(3, 'Отдел 1', 'Описание');


insert into "List of workers" ("ID department", "Full name worker", "Worker location", "Worker room", "Worker contact phone") values
(1, 'Леха лехавич лехао', 'ДС-2', '234', '79358794532'),
(2, 'Максим максимович максимов', 'ДС-2', '674', '85473451290'),
(3, 'Матвей матвеевич матвео', 'ДС-2', '789', '95467893421'),
(4, 'Денис ознович озон', 'озон', '666', '74567892134');

insert into "List of equipment" ("Name equipment", "Description equipment") values
('Персональный компьютер', 'Описание'),
('Принтер', 'Описание'),
('Третий инструмент', 'Описание'),
('Четвертый инструмент', 'Описание');

insert into "Employee equipment" ("ID worker", "ID equipment") values
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(1, 2),
(2, 2),
(3, 2),
(4, 2);

insert into "List of workers PC" ("ID worker", "RDP author PC") values 
(1, '127.13.23.3'),
(2, '3.13.12.13'),
(3, '17.124.343.45'),
(4, '123.123.123.123');


insert into "List of workers accounts" ("ID worker", "Login", "Password", "Group privilege") values
(1, 'Lexa', 'PasswordLexi', 'worker by request'),
(2, 'Maksim', 'Password', 'worker by request'),
(3, 'Matvey', 'Password', 'worker'),
(4,'Denis', 'PasswordDenisa', 'worker');

insert into "List of required service category" ("ID department", "Name required service category", "Description required service category") values
(1, 'Починка подключения к сети', 'Описание'),
(2, 'Починка подлючения к электричеству', 'Описание');

insert into "List of required services" ("ID required service category", "ID equipment" , "Name required service", "Description required service") values
(1, 1 , 'Починка подключение к сети у персонального компьютера', 'Описание'),
(2, 1 , 'Починка подключение к электросети у персонального компьютера', 'Описание'),
(1, 2 , 'Починка подключения к сети у принтера', 'Описание'),
(2, 2, 'Починка подключения к электросети у принтера', 'Описание');

insert into "Possible status request" ("Status name", "Description status") values
('Ожидание', 'Описание'),
('Принят', 'Описание'),
('Выполнен', 'Описание'),
('Отклонена', 'Описание');

select partitions_log_table();

-- проверялка

select * from "Activity History";
select * from "Request";
select * from "List of required services";
select * from "List of workers accounts";
select * from "List of workers";
select * from "List of equipment";
select * from "Employee equipment";
select * from "List of workers PC";
select * from "List of required service category";
select * from "List of required services";
SELECT * FROM "Activity_History_2026_03";
SELECT * FROM "Archival request_2026_03";


-- апдейталка

UPDATE "Request" SET "Required service" = 'Починка подключения к сети у принтера' WHERE "ID request" = 1;

update "List of workers"
set "Full name worker" = 'не леха лехавич'
where "ID worker" = 1;

update "List of companies"
set "Name company" = 'компания лех'
where "ID company" = 1;


update "List of required services"
set "Name required service" = 'ыпырукцрупопоиги'
where "ID required service" = 4;


----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--утилиты для скриптов

DROP FUNCTION IF EXISTS "fill fields about worker information"();
DROP TRIGGER IF EXISTS "fill worker info on request"
ON "Request";
drop function if exists "fiil fields about name worker in table about pc"();
drop trigger if exists "trigger for fiil fields about name worker in table about pc"
on "List of workers PC";
drop function if exists "fill fields about id required service and id required service category"();
drop trigger if exists "trigger for fill fields about id required service"
on "Request";
drop function if exists "writeinlogonchange"();
drop trigger if exists "triggerforwriteinlogonchange"
on "Request";
drop function if exists partitions_log_table();
drop function if exists udawitr();
drop trigger if exists tfudawitr
on "Request";
drop function if exists uudp();
drop trigger if exists tfuudp
on "Request";
drop function if exists ucn();
drop trigger if exists tfucn
on "Request";
drop function if exists usn();
drop trigger if exists tfusn
on "Request";
drop function if exists udn();
drop trigger if exists tfudn
on "Request";
drop function if exists uns();
drop trigger if exists tfuns
on "Request";
drop function if exists unr();
drop trigger if exists tfunr
on "Request";
drop function if exists aodriiar();
drop trigger if exists tfaodriiar
on "Request";



--функция скрипт для авто заполнения id требуемой работы

create function "fill fields about id required service"()
returns trigger as $$
begin
	if (TG_OP = 'INSERT' or old."Required service" is distinct from new."Required service") then
        select "ID required service" 
		into new."ID required service"
        from "List of required services"
        where "Name required service" = new."Required service";
    end if;

    if (TG_OP = 'INSERT' or old."Request status" is distinct from new."Request status") then
        select "ID status request" 
		into new."ID status request"
        from "Possible status request"
        where "Status name" = new."Request status";
    end if;

	if (TG_OP = 'INSERT' or old."Subject of the application" is distinct from new."Subject of the application") then
		select "ID equipment"
		into new."ID equipment"
		from "List of equipment"
		where "Name equipment" = new."Subject of the application";
	end if;
		
	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger "trigger for fill fields about id required service"
before insert or update
on "Request"
for each row
execute function "fill fields about id required service"();

--функция скрипт для авто заполнения лист оф воркерс пс 

create function "fiil fields about name worker in table about pc"()
returns trigger as $$
begin
	select w."Full name worker"
    into new."Full name worker"
    from "List of workers" w
    where w."ID worker" = new."ID worker";

	select 
        q."Inventory number equipment"
    into new."Inventory number"
    from "List of equipment" e
    join "Employee equipment" q on q."ID equipment" = e."ID equipment"
    where 
        e."Name equipment" = 'Персональный компьютер'
        and q."ID worker" = new."ID worker";
	
    return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger "trigger for fiil fields about name worker in table about pc"
BEFORE INSERT 
ON "List of workers PC"
FOR EACH ROW
EXECUTE FUNCTION "fiil fields about name worker in table about pc"();

--функция скрипт для авто заполнения таблицы заказы 

create function "fill fields about worker information"()
returns trigger as $$
declare 
	"record" record;
begin
	select
		p."Inventory number",
		p."RDP author PC",
		w."ID worker",
		w."Full name worker",
		w."Worker location",
		w."Worker room",
		w."Worker contact phone",
		d."ID department",
		d."Name department",
		s."ID service",
		s."Name service",
		c."ID company",
		c."Name company"
	into "record"
	from  "List of workers PC" p
	join "List of workers" w on w."ID worker" = p."ID worker"
	join "List of departments" d on d."ID department" = w."ID department"
	join "List of services" s on  s."ID service" = d."ID service"
	join "List of companies" c on c."ID company" = s."ID company"
	where p."Inventory number" = new."Inventory number";

	if found then
		new."RDP author PC"           := "record"."RDP author PC";
		new."Applicant’s id"          := "record"."ID worker";
		new."Applicant’s full name"   := "record"."Full name worker";
		new."Author"                  := "record"."Full name worker";
    	new."Applicant’s location"    := "record"."Worker location";
    	new."Applicant’s room"        := "record"."Worker room";
    	new."Applicant’s contact phone" := "record"."Worker contact phone";
		new."ID department"           := "record"."ID department";
    	new."Applicant’s department"  := "record"."Name department";
		new."ID service"              := "record"."ID service";
    	new."Applicant’s service"     := "record"."Name service";
		new."ID company"              := "record"."ID company";
    	new."Applicant’s company"     := "record"."Name company";
	end if;

	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

CREATE TRIGGER "fill worker info on request"
BEFORE INSERT 
ON "Request"
FOR EACH ROW
EXECUTE FUNCTION "fill fields about worker information"();

--функция скрипт для заполнения логов

create function "writeinlogonchange"()
returns trigger as $$
declare 
	action_type varchar(20);
    log_desc varchar(750);
    worker_id integer;	
	worker_name varchar(80);
	skip_log text;
begin 

	skip_log := current_setting('my_app.suppress_log', true);
	if skip_log = 'on' then
        return new;
    end if;
	
	worker_id := NULLIF(current_setting('daily_planner.current_user', true), '')::integer;

	select "Full name worker" 
	into worker_name 
	from "List of workers" 
	where "ID worker" = worker_id;
	
	if (TG_OP = 'INSERT') then
		action_type := 'insert';
        log_desc := 'Работник с идентификатором: "' || worker_id || '" и с именем: "'|| NEW."Author" || '" создал заявку с идентификатором: "' || new."ID request" || '"';
	elsif (TG_OP = 'UPDATE') then
		action_type := 'update';
		if (old."Request status" = new."Request status" and old."Required service" is distinct from new."Required service" and old."Technical staff response" is distinct from  new."Technical staff response") then
			log_desc := 'Работник с идентификатором: "' || worker_id || '" под именем: "' || worker_name || '" изменил требуемый сервис с: "' || old."Required service" || '" на: "' || new."Required service" || '" и поменял на ответ технического персонала c: "' 
			|| coalesce(old."Technical staff response", 'значения нет ибо новая заявка') || '" на: "' || new."Technical staff response" || '" в заявке под идентификатором: "' || new."ID request" || '"';
		elsif (old."Request status" is distinct from new."Request status" and old."Required service" = new."Required service" and old."Technical staff response" is distinct from new."Technical staff response") then
			log_desc := 'Работник с идентификатором: "' || worker_id || '" под именем: "' || worker_name || '" изменил статус заявки с: "' || old."Request status" || '" на: "' || new."Request status" || '" и поменял на технического персонала c: "' 
			|| coalesce(old."Technical staff response", 'значения нет ибо новая заявка') || '" на: "' || new."Technical staff response" || '" в заявке под идентификатором: "' || new."ID request" || '"';
		elsif (old."Request status" is distinct from new."Request status" and old."Required service" is distinct from new."Required service" and old."Technical staff response" is distinct from new."Technical staff response") then
			log_desc := 'Работник с идентификатором: "' || worker_id || '" под именем: "' || worker_name || '" изменил статус заявки с: "' || old."Request status" || '" на: "' || new."Request status" || '" и поменял требуемый сервис c: "' 
			|| old."Required service" || '" на: "' || new."Required service" || '" а также поменял технического персонала c: "' || coalesce(old."Technical staff response", 'значения нет ибо новая заявка') || '" на: "' || new."Technical staff response" 
			|| '" в заявке под идентификатором: "' || new."ID request" || '"';	
		end if;
	end if;

	insert into "Activity History" ("ID request", "ID worker", "Action type", "Log description", "Date change") values
	(new."ID request", worker_id, action_type, log_desc, now());

	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger "triggerforwriteinlogonchange"
after insert or update of "Request status", "Required service", "Technical staff response"
ON "Request"
for each row
execute function "writeinlogonchange"();

--функция скрипт для авто делания таблицы логов по месяцам

create function partitions_log_table()
returns void as $$
declare
    curr_month date;
    next_month date;
    partition_name text;
begin
    for i in 0..1 loop
        curr_month := date_trunc('month', now() + (i || ' month')::interval);
        next_month := curr_month + interval '1 month';
        partition_name := '"Activity_History_' || to_char(curr_month, 'YYYY_MM') || '"';

        -- Если таблицы нет — создаем
        if not exists (select 1 from pg_class c join pg_namespace n on n.oid = c.relnamespace 
                       where c.relname = replace(partition_name, '"', '') and n.nspname = 'public') then
            execute format('CREATE TABLE %s PARTITION OF "Activity History" FOR VALUES FROM (%L) TO (%L)', 
                           partition_name, curr_month, next_month);
        end if;

		partition_name := '"Archival request_' || to_char(curr_month, 'YYYY_MM') || '"';

		if not exists (select 1 from pg_class c join pg_namespace n on n.oid = c.relnamespace 
                       where c.relname = replace(partition_name, '"', '') and n.nspname = 'public') then
            execute format('CREATE TABLE %s PARTITION OF "Archival request" FOR VALUES FROM (%L) TO (%L)', 
                           partition_name, curr_month, next_month);
        end if;
		
    end loop;
end;
$$ language plpgsql; 


--psql -U postgres -d имя_базы -c "SELECT partitions_log_table(); это для кмд типо чтоб каждый месяц прокнулся

--теперь точно для авто апдейта данных в заявке о воркере

create function udawitr()
returns trigger as $$
begin

	update "Request"
    set 
        "Applicant’s full name" = case 
            when old."Full name worker" IS DISTINCT FROM new."Full name worker" 
            then new."Full name worker"  else "Applicant’s full name" end,

		"Author" = case 
            when old."Full name worker" IS DISTINCT FROM new."Full name worker" 
            then new."Full name worker" else "Author" end,
            
        "Applicant’s location" = case 
            when old."Worker location" IS DISTINCT FROM new."Worker location" 
            then new."Worker location" else "Applicant’s location" end,
            
        "Applicant’s room" = case 
            when old."Worker room" IS DISTINCT FROM new."Worker room" 
            then new."Worker room" else "Applicant’s room" end,
            
        "Applicant’s contact phone" = case 
            when old."Worker contact phone" IS DISTINCT FROM new."Worker contact phone" 
            then new."Worker contact phone" else "Applicant’s contact phone" end
    where "Applicant’s id" = new."ID worker";	

	if (old."Full name worker" IS DISTINCT FROM new."Full name worker") then
		update "List of workers PC"
		set "Full name worker" = new."Full name worker"
		where "ID worker" = new."ID worker";
	end if;
	
	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger tfudawitr
after update
on "List of workers"
for each row
execute function udawitr();

--для обновления рдр адресса 

create function uudp()
returns trigger as $$
begin

	update "Request"
	set "RDP author PC" = new."RDP author PC"
	where "Applicant’s id" = new."ID worker";

	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger tfuudp
after update of "RDP author PC"
on "List of workers PC"
for each row
execute function uudp();

--обновлялка имени компании

create function ucn()
returns trigger as $$
begin

	update "Request"
	set "Applicant’s company" = new."Name company"
	where "ID company" = new."ID company";

	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger tfucn
after update of "Name company"
on "List of companies"
for each row
execute function ucn();

--обновлялка имени сервиса

create function usn()
returns trigger as $$
begin

	update "Request"
	set "Applicant’s service" = new."Name service"
	where "ID service" = new."ID service";

	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger tfusn
after update of "Name service"
on "List of services"
for each row
execute function usn();

--обновление имени отдела

create function udn()
returns trigger as $$
begin

	update "Request"
	set "Applicant’s department" = new."Name department"
	where "ID department" = new."ID department";

	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger tfudn
after update of "Name department"
on "List of departments"
for each row
execute function udn();

--обновлялка для имени субьекта заявки

create function uns()
returns trigger as $$
begin

	perform set_config('my_app.suppress_log', 'on', true);
	
	update "Request"
	set "Subject of the application" = new."Name equipment"
	where "ID equipment" = new."ID equipment";

	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger tfuns
after update of "Name equipment"
on "List of equipment"
for each row
execute function uns();

--обновлялка для необходимого сервиса

create function unr()
returns trigger as $$
begin

	perform set_config('my_app.suppress_log', 'on', true);
	
	update "Request"
	set "Required service" = new."Name required service"
	where "ID required service" = new."ID required service";

	return new;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger tfunr
after update of "Name required service"
on "List of required services"
for each row
execute function unr();

-- функция скрипт для добавления в архив реквесет

create function aodriiar()
returns trigger as $$
begin

	insert into "Archival request" (
		"ID request",
		"Author",
		"ID company",
		"Applicant’s company",
		"ID service",
		"Applicant’s service",
		"ID department",
		"Applicant’s department",
		"Applicant’s id",
		"Applicant’s full name",
		"Applicant’s location",
		"Applicant’s room",
		"Applicant’s contact phone",
		"Inventory number subject",
		"ID equipment",
		"Subject of the application",
		"ID required service",
		"Required service",
		"Inventory number",
		"RDP author PC",
		"Date of beginning of archive",
		"Description request",
		"ID status request",
		"Request status",
		"Technical staff response"		
	) values
	(
		old."ID request",
		old."Author",
		old."ID company",
		old."Applicant’s company",
		old."ID service",
		old."Applicant’s service",
		old."ID department",
		old."Applicant’s department",
		old."Applicant’s id",
		old."Applicant’s full name",
		old."Applicant’s location",
		old."Applicant’s room",
		old."Applicant’s contact phone",
		old."Inventory number subject",
		old."ID equipment",
		old."Subject of the application",
		old."ID required service",
		old."Required service",
		old."Inventory number",
		old."RDP author PC",
		now(),
		old."Description request",
		old."ID status request",
		old."Request status",
		old."Technical staff response"
	);

	insert into "Activity History" ("ID request", "Action type", "Log description", "Date change") values
	(old."ID request", 'delete', 'Из-за архивации из таблицы "Request" удалена заявка с идентификатором: "' || old."ID request" || '"' , now());
	
	return old;
end;
$$ language plpgsql
SECURITY DEFINER;

create trigger tfaodriiar
after delete 
on "Request"
for each row
execute function aodriiar();

--процедура для удаления старых заявок

create procedure deleteoldrequest()
language plpgsql
SECURITY DEFINER
as $$
begin 
	delete from "Request"
	where "Date of request submission" < now() - interval '3 months';

end;
$$;


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--роли и узеры
	 
-- пароль от postgres - qwerty port 5432 host localhost bd DailyPlanner
select current_user;

drop user "worker by request";
drop user "worker";

--создание роли для воркера по работе с заявками
create user "worker by request" with password 'passwordforrequest';
--просто нужно
grant usage on schema public to "worker by request";
--права необходимые для того чтобы обработать заявку
grant update ("Required service", "Last modified date", "Request status", "Technical staff response") on table "Request" to "worker by request";
grant select on table "Request" to "worker by request";
grant select on table "List of required services" to "worker by request";
grant select on table "List of required service category" to "worker by request";
grant select on table "Possible status request" to "worker by request";
grant select on table "List of departments" to "worker by request";
grant select on table "Activity History" to "worker by request";
--права необходимые для того чтобы создать заявку
grant select on table "Employee equipment" to "worker by request";
grant insert on table "Request" to "worker by request";
grant select on table "List of workers accounts" to "worker by request";
grant select on table "List of workers" to "worker by request";
grant select on table "List of equipment" to "worker by request";
grant select on table "List of workers PC" to "worker by request";
grant usage on sequence "Request_ID request_seq" to "worker by request";
grant select on table "List of services" to "worker by request";
grant select on table "List of companies" to "worker by request";


--создание роли для воркера обычного
create user "worker" with password 'password';
--просто нужно
grant usage on schema public to "worker";
--права необходимые чтобы создать заявку
grant select on table "Employee equipment" to "worker";
grant select on table "List of equipment" to "worker";
grant insert on table "Request" to "worker";
grant select on table "Request" to "worker";
grant select on table "List of required services" to "worker";
grant select on table "List of workers accounts" to "worker";
grant select on table "List of workers" to "worker";
grant select on table "Possible status request" to "worker";
grant select on table "List of workers PC" to "worker";
grant usage on sequence "Request_ID request_seq" to "worker";
grant select on table "List of services" to "worker";
grant select on table "List of companies" to "worker";
grant select on table "List of departments" to "worker";

--для провекри имени последовательности
SELECT pg_get_serial_sequence('"Request"', 'ID request');
