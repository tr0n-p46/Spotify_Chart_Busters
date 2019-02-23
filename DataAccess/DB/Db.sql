create database SpotifyDB;

use SpotifyDB;

create table ChartBusters(
	id int auto_increment primary key,
	name varchar(100) not null,
    artists varchar(50),
    danceability float,
    energy float,
    `key` int,
    loudness float,
	mode int,
    speechiness float,
    acousticness float,
    instrumentalness float,
    liveness float,
    valence float,
    tempo float,
    duration_ms int,
    time_signature int,
    `rank` int
);

drop table ChartBusters;

describe ChartBusters;

SELECT @@secure_file_priv;

LOAD DATA INFILE "C:\\ProgramData\\MySQL\\MySQL Server 8.0\\Uploads\\top_spotify_021e61205.csv"
INTO TABLE ChartBusters 
COLUMNS TERMINATED BY ','
OPTIONALLY ENCLOSED BY '"'
ESCAPED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES
(	name,
    artists,
    danceability,
    energy,
    `key`,
    loudness,
    mode,
    speechiness,
    acousticness,
    instrumentalness,
    liveness,
    valence,
    tempo,
    duration_ms,
    time_signature,
    `rank`);
    
delete from ChartBusters;

select * from ChartBusters;

