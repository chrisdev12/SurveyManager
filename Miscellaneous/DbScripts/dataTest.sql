USE [IVR_Survey]
GO

INSERT INTO Survey (SurveyId, Description) 
	VALUES 
	('123', 'Encuesta de prueba número uno'), 
	('432423','Encuesta de prueba número dos');

INSERT INTO QuestionSurvey (QuestionId, Description, SurveyId) 
	VALUES 
	('1', '¿Quien es lupita?', '123'),
	('2', '¿Quien es Cobarde?', '123'), 
	('3', '¿Quien es Sim?', '123'), 
	('4', '¿Quien es Homero Simpson?', '123'),
	('5', '¿Quien es Garu?', '123'), 
	('1','¿Le gustaria medicina prepagada?', '432423'),
	('2','¿Se siente feliz en su eps?', '432423'),
	('3','¿Cree que su salud está bien resguardada?', '432423'),
	('4','¿Tiene conocimiento de sus derechos?', '432423'),
	('5','¿Ha tenido lios con su eps en los últimos 6 meses?', '432423');

	INSERT INTO QuestionSurvey (QuestionId, Description, SurveyId) 
	VALUES 
	('1', '¿Quien es lupita?', '123qweqe');