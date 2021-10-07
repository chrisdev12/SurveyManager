USE [IVR_Survey]
GO

--The schema ws may be created
SET XACT_ABORT ON 
BEGIN TRAN  
	CREATE TABLE [ws].[Survey] (
		Id VARCHAR(10) NOT NULL PRIMARY KEY,
		Description VARCHAR(255) NOT NULL,
	);

	CREATE TABLE [ws].[QuestionSurvey] (
		Id VARCHAR(10) NOT NULL,
		Description VARCHAR(255) NOT NULL,
		SurveyId VARCHAR(10) NOT NULL,
		PRIMARY KEY (Id,SurveyId),
		FOREIGN KEY (SurveyId) REFERENCES ws.Survey(Id)
	);

	CREATE TABLE [ws].[MemberSurveyResult] (
		ContractNumber VARCHAR(20) NOT NULL,
		Name VARCHAR(30),
		LastName VARCHAR(30),
		PhoneNumber VARCHAR(20),
		AlternativephoneNumber VARCHAR(20),
		IpaNumber VARCHAR(10),
		PcpName VARCHAR(30),
		PcpNPINumber VARCHAR(20),
		CallDate DATETIME,
		Disposition VARCHAR(10),
		QuestionId VARCHAR(10) NOT NULL,
		SurveyId VARCHAR(10) NOT NULL,
		AnswerDescription VARCHAR(255) NOT NULL,
		AnswerPhoneDigit VARCHAR(2) NOT NULL,
		UpdatedDate DATETIME NOT NULL,
		PRIMARY KEY(ContractNumber,QuestionId, SurveyId),
		FOREIGN KEY (QuestionId, SurveyId) REFERENCES ws.QuestionSurvey(Id, SurveyId),
		FOREIGN KEY (SurveyId) REFERENCES ws.Survey(Id)
	);
COMMIT TRAN