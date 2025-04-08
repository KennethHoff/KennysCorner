import { FileUser, RssIcon } from "lucide-react";
import { TooltipProvider, TooltipTrigger, Tooltip, TooltipContent } from "./ui/tooltip";

export function ResumeLink() {
    return (
        <TooltipProvider>
            <Tooltip>
                <TooltipTrigger asChild>
                    <a href="/resume" aria-label="Resumé">
                        <FileUser aria-hidden />
                    </a>
                </TooltipTrigger>
                <TooltipContent>Kenneth Hoff's resumé</TooltipContent>
            </Tooltip>
        </TooltipProvider>
    );
}

export function CuriosRssFeedLink() {
    return (
        <TooltipProvider>
            <Tooltip>
                <TooltipTrigger asChild>
                    <a href="/curios/rss.xml" aria-label="RSS Feed for Kenny's Curios">
                        <RssIcon aria-hidden />
                    </a>
                </TooltipTrigger>
                <TooltipContent>RSS Feed for Kenny's Curios</TooltipContent>
            </Tooltip>
        </TooltipProvider>
    );
}
