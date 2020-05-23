ALTER TABLE Users
ADD CONSTRAINT [CK__USERS__Password]
CHECK(LEN([password]) >= 5)