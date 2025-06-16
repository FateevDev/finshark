namespace FinShark.API.Exceptions;

public class UpdateCommentException(string message) : Exception(message)
{
    public static UpdateCommentException CanNotUpdateOtherUserComment()
    {
        return new("You can update only your own comments");
    }
}