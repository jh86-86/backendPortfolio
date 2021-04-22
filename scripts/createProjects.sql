CREATE TABLE Events (
  Id SERIAL PRIMARY KEY,
  Name VARCHAR(50),
  Link TEXT,
  Image TEXT,
  Project TEXT,
  Description TEXT,
);

INSERT INTO Events
  (Name, Description, ExerciseType, Longitude, Latitude, Time, Intensity, GroupId)
VALUES
  ('Park run','Come join us to run in the park!','running', 52.4862, 1.8904,'2021-04-09 19:10:25-07','easy', 1),
  ('Roadride', 'Come join us to ride 50k: On Saturday morning early, before breakfast!', 'running', 52.4862, 1.8904, '2021-04-10 19:10:25-07', 'easy', 1),
  ('Learning Swimming','Come join us at the lido','swimming', 52.4862, 1.8904 ,'2021-04-11 19:10:25-07','easy', 1);
