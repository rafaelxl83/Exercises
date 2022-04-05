create table test_groups (
    name varchar(40) not null, 
    test_value integer not null, 
    unique(name)
  );
  
  create table test_cases (
     id integer not null, 
     group_name varchar(40) not null, 
     status varchar(5) not null, 
     unique(id)
  );
  
  insert into test_groups (name, test_value)
  VALUES
  ('performance', 15),
  ('corner cases', 10), 
  ('numerical stability', 20), 
  ('memory usage', 10);
  
  insert into test_cases (id, group_name, status)
  VALUES 
  (13, 'memory usage', 'OK'),
  (14, 'numerical stability', 'OK'),
  (15, 'memory usage', 'ERROR'),
  (16, 'numerical stability', 'OK'),
  (17, 'numerical stability', 'OK'),
  (18, 'performance', 'ERROR'),
  (19, 'performance', 'ERROR'),
  (20, 'memory usage', 'OK'),
  (21, 'numerical stability', 'OK');

  -- Solution 3
  SELECT CASE
           WHEN g.name = c.group_name THEN c.group_name
           ELSE g.name
       END AS name,
       count(c.group_name) AS all_test_cases,
       count(CASE
                 WHEN c.status = 'OK' THEN 1
             END) AS all_test_cases,
       sum(CASE
               WHEN c.status = 'OK' THEN g.test_value
               ELSE 0
           END) AS total_value
FROM test_groups g
LEFT JOIN test_cases c ON g.name = c.group_name
GROUP BY CASE
             WHEN g.name = c.group_name THEN c.group_name
             ELSE g.name
         END
ORDER BY total_value DESC,
         CASE
             WHEN g.name = c.group_name THEN c.group_name
             ELSE g.name
         END
