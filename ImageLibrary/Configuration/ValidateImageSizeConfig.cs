namespace ImageLibrary.Configuration;

public class ValidateImageSizeConfig : IValidateOptions<ImageSizeConfig>
{
    public ValidateOptionsResult Validate(string? name, ImageSizeConfig options)
    => name == ImageSizeConfig.Thumbnail && options.Width > 96
        ? ValidateOptionsResult.Fail("From Validator: Thumbnail must be 96px or smaller")
        : ValidateOptionsResult.Success;
}
