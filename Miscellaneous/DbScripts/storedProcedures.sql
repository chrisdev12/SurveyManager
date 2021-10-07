USE [IVR_Survey]
GO

/* Get a survey by id: sp_WS_GetSurveyById */
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_WS_GetSurveyById')
BEGIN 		
	DROP PROCEDURE [ws].[sp_WS_GetSurveyById];
END
GO
CREATE PROCEDURE [ws].[sp_WS_GetSurveyById]
	@SurveyId VARCHAR(10)
	AS
	BEGIN
		SELECT * FROM [ws].[Survey] WHERE [Id] = @SurveyId;
	END
GO

/* Permissions sp_WS_GetSurveyById
GRANT EXECUTE ON [ws].[sp_WS_GetSurveyById] to [domain1\c_cbravo]
GRANT VIEW DEFINITION ON [ws].[sp_WS_GetSurveyById] to [User_StoredProc_Exec]
GO */

-----------------------------------------------------------------------------------------

/* Update a survey by id: sp_WS_UpdateSurveyById */
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_WS_UpdateSurveyById')
BEGIN 		
	DROP PROCEDURE [ws].[sp_WS_UpdateSurveyById];
END
GO
CREATE PROCEDURE [ws].[sp_WS_UpdateSurveyById]
	@SurveyId VARCHAR(10),
	@Description VARCHAR(255)
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [ws].[Survey]
		SET "Description" = @Description
		WHERE [Id] = @SurveyId
	END
GO

/* Permissions sp_WS_UpdateSurveyById 
GRANT EXECUTE ON [ws].[sp_WS_UpdateSurveyById] to [domain1\c_cbravo]
GRANT VIEW DEFINITION ON [ws].[sp_WS_UpdateSurveyById] to [User_StoredProc_Exec]
GO */

--------------------------------------------------------------------------------------

/* Insert a  new survey: sp_WS_InsertSurvey */
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_WS_InsertSurvey')
BEGIN 		
	DROP PROCEDURE [ws].[sp_WS_InsertSurvey];
END
GO
CREATE PROCEDURE [ws].[sp_WS_InsertSurvey]
	@SurveyId VARCHAR(10),
	@Description VARCHAR(255)
	AS
	BEGIN
		SET NOCOUNT ON;

		INSERT INTO [ws].[Survey] 
			(Id, 
			Description)
		VALUES 
			(@SurveyId, 
			@Description);
	END
GO

/* Permissions sp_WS_InsertSurvey 
GRANT EXECUTE ON [ws].[sp_WS_InsertSurvey] to [domain1\c_cbravo]
GRANT VIEW DEFINITION ON [ws].[sp_WS_InsertSurvey] to [User_StoredProc_Exec]
GO */

-------------------------------------------------------------------------------------------

/* Get all questions of a Survey: sp_WS_GetSurveyQuestions */
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_WS_GetSurveyQuestions')
BEGIN 		
	DROP PROCEDURE [ws].[sp_WS_GetSurveyQuestions];
END
GO
CREATE PROCEDURE [ws].[sp_WS_GetSurveyQuestions]
	@SurveyId VARCHAR(10)
	AS
	BEGIN
		SET NOCOUNT ON;

		SELECT MS.Id, MS.Description, S.Id AS SurveyId 
		FROM [ws].[QuestionSurvey] MS 
		INNER JOIN [ws].[Survey] S 
		ON MS.SurveyId = S.Id 
		WHERE MS.SurveyId = @SurveyId
	END
GO

/* Permissions sp_WS_GetAnswersOfSurvey
GRANT EXECUTE ON [ws].[sp_WS_GetSurveyQuestions] to [domain1\c_cbravo]
GRANT VIEW DEFINITION ON [ws].[sp_WS_GetSurveyQuestions] to [User_StoredProc_Exec]
GO */

---------------------------------------------------------------------------------------------

/* Update a survey question: sp_WS_UpdateQuestion */
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_WS_UpdateQuestion')
BEGIN 		
	DROP PROCEDURE [ws].[sp_WS_UpdateQuestion];
END
GO
CREATE PROCEDURE [ws].[sp_WS_UpdateQuestion]
	@QuestionId VARCHAR(10),
	@SurveyId VARCHAR(10),
	@Description VARCHAR(255)
	AS
	BEGIN
		SET NOCOUNT ON;

		UPDATE [ws].[QuestionSurvey]
		SET "Description" = @Description
		WHERE [SurveyId] = @SurveyId 
		AND [Id] = @QuestionId
	END
GO

/* Permissions sp_WS_UpdateQuestion
GRANT EXECUTE ON [ws].[sp_WS_UpdateQuestion] to [domain1\c_cbravo]
GRANT VIEW DEFINITION ON [ws].[sp_WS_UpdateQuestion] to [User_StoredProc_Exec]
GO */

--------------------------------------------------------------------------------------------------------

/* Insert a  new question: sp_WS_InsertQuestion */
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_WS_InsertQuestion')
BEGIN 		
	DROP PROCEDURE [ws].[sp_WS_InsertQuestion];
END
GO
CREATE PROCEDURE [ws].[sp_WS_InsertQuestion]
	@QuestionId VARCHAR(10),
	@SurveyId VARCHAR(10),
	@Description VARCHAR(255)
	AS
	BEGIN
		SET NOCOUNT ON;

		INSERT INTO [ws].[QuestionSurvey] 
			(Id,
			Description,
			SurveyId)
		VALUES 
			(@QuestionId,
			@Description,
			@SurveyId);
	END
GO

/* Permissions sp_WS_InsertQuestion 
GRANT EXECUTE ON [ws].[sp_WS_InsertQuestion] to [domain1\c_cbravo]
GRANT VIEW DEFINITION ON [ws].[sp_WS_InsertQuestion] to [User_StoredProc_Exec]
GO */
---------------------------------------------------------------------------------------

/* Insert or update a new MemberSurveyResult: sp_WS_InsertQuestion */

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_WS_InsertMemberSurveyResult')
BEGIN 		
	DROP PROCEDURE [ws].[sp_WS_InsertMemberSurveyResult];
END
GO
CREATE PROCEDURE [ws].[sp_WS_InsertMemberSurveyResult]
	@ContractNumber VARCHAR(20),
	@Name VARCHAR(30),
	@LastName VARCHAR(30),
	@PhoneNumber VARCHAR(20),
	@AlternativephoneNumber VARCHAR(20) = NULL,
	@IpaNumber VARCHAR(10),
	@PcpName VARCHAR(30),
	@PcpNPINumber VARCHAR(20),
	@CallDate DATETIME,
	@Disposition VARCHAR(10)  = NULL,
	@QuestionId VARCHAR(10),
	@SurveyId VARCHAR(10),
	@AnswerDescription VARCHAR(255),
	@AnswerPhoneDigit VARCHAR(2) = NULL
	AS
	BEGIN
		SET NOCOUNT ON;
		IF NOT EXISTS (SELECT * FROM [ws].[MemberSurveyResult]
			WHERE ContractNumber = @ContractNumber 
			AND QuestionId = @QuestionId
			AND SurveyId = @SurveyId) 
		
		BEGIN
			INSERT INTO [ws].[MemberSurveyResult] 
			(ContractNumber,
			Name,
			LastName,
			PhoneNumber,
			AlternativephoneNumber,
			IpaNumber,
			PcpName,
			PcpNPINumber,
			CallDate,
			Disposition,
			QuestionId,
			SurveyId,
			AnswerDescription,
			AnswerPhoneDigit,
			UpdatedDate)
			VALUES 
			(@ContractNumber,
			@Name,
			@LastName,
			@PhoneNumber,
			@AlternativephoneNumber,
			@IpaNumber,
			@PcpName,
			@PcpNPINumber,
			@CallDate,
			@Disposition,
			@QuestionId,
			@SurveyId,
			@AnswerDescription,
			@AnswerPhoneDigit,
			GETDATE()
			);
		END

		ELSE
		BEGIN
			UPDATE [ws].[MemberSurveyResult]
			SET
				Name = @Name,
				LastName = @LastName,
				PhoneNumber = @PhoneNumber,
				AlternativephoneNumber = @AlternativephoneNumber,
				IpaNumber = @IpaNumber,
				PcpName = @IpaNumber,
				PcpNPINumber = @PcpNPINumber,
				CallDate = @CallDate,
				Disposition = @Disposition,
				AnswerDescription = @AnswerDescription,
				AnswerPhoneDigit = @AnswerPhoneDigit,
				UpdatedDate = GETDATE()

			WHERE [ContractNumber] = @ContractNumber
			AND [QuestionId] = @QuestionId
			AND [SurveyId] = @SurveyId
		END
	END
GO

/* Permissions sp_WS_InsertQuestion
GRANT EXECUTE ON [sp_WS_InsertMemberSurveyResult] to [domain1\c_cbravo]
GRANT VIEW DEFINITION ON [sp_WS_InsertMemberSurveyResult] to [User_StoredProc_Exec]
GO
*/
